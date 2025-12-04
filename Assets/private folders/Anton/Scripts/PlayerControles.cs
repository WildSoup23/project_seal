using System;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;

public class PlayerControles : MonoBehaviour
{
    // Controles player dive, acceleration, max speed

    [SerializeField] private AudioSource audioSource;
    
    public float changedGravityScale;
    
    [SerializeField] private GameObject gameObject;
    private float rotateAmount;
    
    private bool allowedToSlam_ByKey;
    private bool allowedToAccelerate;
    
    public float maxVelocity_X;
    public float speedMultiplier;

    [SerializeField] private bool UpgradesActive;
    
    private const string path = @"c:\temp\test.txt";

    [SerializeField] private CoinsCollected coins;

    private void Awake()
    {
        allowedToSlam_ByKey = false;
    }

    private void Start()
    {
        if (UpgradesActive)
        {
            ApplyUpgrades();
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        if (gameObject.GetComponent<Rigidbody2D>().linearVelocity.y < -35)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(
                gameObject.GetComponent<Rigidbody2D>().linearVelocity.x,
                -35);
        }
        
        if (gameObject.GetComponent<Rigidbody2D>().linearVelocity.x > maxVelocity_X)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(maxVelocity_X,
                gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
        }
        
        else if (gameObject.GetComponent<Rigidbody2D>().linearVelocity.x < -maxVelocity_X)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-maxVelocity_X,
                gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
        }
        
        // Debug.Log(gameObject.GetComponent<Rigidbody2D>().linearVelocity);
        
        if (allowedToSlam_ByKey)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = changedGravityScale;

            if (allowedToAccelerate)
            {
                gameObject.GetComponent<Rigidbody2D>().linearVelocity *= new Vector2(speedMultiplier, 1);
            }        
        }

        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slope"))
        {
            audioSource.Play();
            allowedToAccelerate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slope"))
        {
            allowedToAccelerate = false;
        }
    }

    public void ApplyUpgrades()
    {
        int playerAttribute = -1;
        foreach (string line in File.ReadLines(path, Encoding.UTF8))
        {
            string parsed = line.Trim();
                
            if (parsed == File.ReadLines(path).First())
            {
                    
            }

            else if (playerAttribute == 0)
            {
                maxVelocity_X += float.Parse(parsed);
            }
                
            else if (playerAttribute == 1)
            {
                float upgr = float.Parse(parsed);
                speedMultiplier += upgr / 10;
            }
                
            else if (playerAttribute == 2)
            {
                changedGravityScale += float.Parse(parsed);
            }
                
            else if (playerAttribute == 3)
            {
                // problem
                coins.coinMultiplier *= float.Parse(parsed);
                break;
            }
                
            playerAttribute++;
        }
    }
}
