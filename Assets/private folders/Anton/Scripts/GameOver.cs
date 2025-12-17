using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public UnityEvent SaveCoins;
    private AudioSource splash;

    private void Start()
    {
        splash = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(splash != null)
            {
                splash.Play();
            }

            SaveCoins?.Invoke();
            Win_Lose_Script.instance.OnTriggerLose();
        }
    }
}
