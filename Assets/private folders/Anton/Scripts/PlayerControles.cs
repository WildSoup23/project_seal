using System;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine.Events;
using Unity.Mathematics;
using System.Collections.Generic;

public class PlayerControles : MonoBehaviour
{
    // Controles player dive, acceleration, max speed

    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource windAudioSource;
    [SerializeField] private AudioSource slideSound;

    private TheKeeper keeper;
    
    // Dive speed
    public float changedGravityScale;

    [SerializeField] private UnityEvent SaveCoins;
    [SerializeField] private GameObject player;
    
    private float rotateAmount;
    [SerializeField] private float timer;
    
    private bool allowedToSlam_ByKey;
    private bool allowedToAccelerate;
    private bool playerIsStuck = false;
    
    // Max speed
    public float maxVelocity_X;
    // Acceleration
    public float speedMultiplier;

    // speed reduction upgrade
    public float speedReductionReduction;

    [SerializeField] private bool UpgradesActive;
    
    private const string path = @"c:\temp\test.txt";

    [SerializeField] private CoinsCollected coins;

    private GameObject pause;
    private GameObject winLose;
    private bool isSliding = false;

    private void Awake()
    {
        allowedToSlam_ByKey = false;
        timer = 0;
    }

    private void Start()
    {
        winLose = GameObject.FindAnyObjectByType<Win_Lose_Script>().gameObject;
        pause = GameObject.FindAnyObjectByType<SceneLoaderManagerScript>().gameObject;

        if (UpgradesActive)
        {
            ApplyUpgrades();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSliding)
        {
            slideSound.pitch = 1 * (player.GetComponent<Rigidbody2D>().linearVelocity.x +
                                         player.GetComponent<Rigidbody2D>().linearVelocity.y) / (maxVelocity_X * 2);
        }
        else
        {
            slideSound.pitch = 1 * (player.GetComponent<Rigidbody2D>().linearVelocity.x -
                                         player.GetComponent<Rigidbody2D>().linearVelocity.y) / (maxVelocity_X * 2);
        }

        if (!player.GetComponent<Rigidbody2D>().simulated ||
           winLose.GetComponent<Win_Lose_Script>().win_lose_panel.activeInHierarchy ||
           pause.GetComponent<SceneLoaderManagerScript>().pause_screen.activeInHierarchy)
        {
            windAudioSource.volume = 0;
        }
        else
        {
            windAudioSource.volume = 1;
        }


        if (player.GetComponent<Rigidbody2D>().linearVelocity.y < 0)
        {
            windAudioSource.pitch = 1 * (player.GetComponent<Rigidbody2D>().linearVelocity.x -
                                         player.GetComponent<Rigidbody2D>().linearVelocity.y) / (maxVelocity_X * 2);
        }

        else
        {
            windAudioSource.pitch = 1 * (player.GetComponent<Rigidbody2D>().linearVelocity.x +
                                         player.GetComponent<Rigidbody2D>().linearVelocity.y) / (maxVelocity_X * 2);
        }
        
        if (windAudioSource.pitch < 0.4)
        {
            windAudioSource.pitch = 0.4f;
        }
        
        if (player.GetComponent<Rigidbody2D>().linearVelocity == new Vector2(0,0) && playerIsStuck)
        {
            SaveCoins?.Invoke();
            Win_Lose_Script.instance.OnTriggerLose();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            allowedToSlam_ByKey = true;
        }

        else
        {
            allowedToSlam_ByKey = false;
        }
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
        // Max velocity downwards
        if (player.GetComponent<Rigidbody2D>().linearVelocity.y < -35)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(
                player.GetComponent<Rigidbody2D>().linearVelocity.x,
                -35);
        }
        
        // Max velocity forwards
        if (player.GetComponent<Rigidbody2D>().linearVelocity.x > maxVelocity_X)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(maxVelocity_X,
                player.GetComponent<Rigidbody2D>().linearVelocity.y);
        }
        
        else if (player.GetComponent<Rigidbody2D>().linearVelocity.x < -maxVelocity_X)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-maxVelocity_X,
                player.GetComponent<Rigidbody2D>().linearVelocity.y);
        }
        
        // Debug.Log(player.GetComponent<Rigidbody2D>().linearVelocity);
        
        if (allowedToSlam_ByKey)
        {
        
            player.GetComponent<Rigidbody2D>().gravityScale = changedGravityScale;
            
            // Here is the acceleration
            if (allowedToAccelerate)
            {
                player.GetComponent<Rigidbody2D>().linearVelocity *= new Vector2(speedMultiplier, 1);
            }        
        }

        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void PlayRandomSlap()
    {
        int rn = UnityEngine.Random.Range(0, 4);
        audioSource.clip = clips[rn];
        audioSource.Play();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slope"))
        {
            isSliding = true;
            slideSound.Play();
            if (timer <= 0)
            {
                PlayRandomSlap();
                timer = 1.16f;
            }
            allowedToAccelerate = true;
        }

        if (other.gameObject.CompareTag("speedReducer") && !other.GetComponent<Enemy>().hasHit)
        {
            other.GetComponent<Collider2D>().enabled = false;
            float StartSpeedReduction = other.GetComponent<Enemy>().SPEED_DECREASE;
            float x = StartSpeedReduction * (1-speedReductionReduction);
            float y = 1 - x;
            GetComponent<Rigidbody2D>().linearVelocity = GetComponent<Rigidbody2D>().linearVelocity * Mathf.Clamp01(y);
            other.GetComponent<Enemy>().hasHit = true;
            other.GetComponent<Enemy>().hitSound.Play();
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Slope") && player.GetComponent<Rigidbody2D>().linearVelocity == new Vector2(0,0))
        {
            playerIsStuck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slope"))
        {
            isSliding = false;
            slideSound.Stop();
            allowedToAccelerate = false;
        }
    }

    public void ApplyUpgrades()
    {
        keeper = GameObject.FindGameObjectWithTag("TheKeeper").GetComponent<TheKeeper>();
        
        int playerAttribute = -1;

        maxVelocity_X = 15 + keeper.speed;
        speedMultiplier = 1.2f + keeper.accel / 10;
        changedGravityScale = 8 + keeper.dive;
        speedReductionReduction = keeper.def / 10;

        /*
        foreach (string line in File.ReadLines(path, Encoding.UTF8))
        {
            string parsed = line.Trim();

            if (parsed == File.ReadLines(path).First())
            {

            }

            else if (playerAttribute == 0)
            {
                maxVelocity_X = 15 + float.Parse(parsed);
            }

            else if (playerAttribute == 1)
            {
                float upgr = float.Parse(parsed);
                speedMultiplier = 1.2f + upgr / 10;
            }

            else if (playerAttribute == 2)
            {
                changedGravityScale = 8 + float.Parse(parsed);
            }

            else if (playerAttribute == 3)
            {
                float upgr = float.Parse(parsed);
                speedReductionReduction = upgr / 10;
            }

            playerAttribute++;
        }
        */
    }

       
}
