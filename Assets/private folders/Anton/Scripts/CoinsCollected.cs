using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinsCollected : MonoBehaviour
{
    // Accumulates coins based on the player's moved X-position
    
    [SerializeField] private GameObject player;

    public float coinMultiplier;
    private int startPosition_X;
    private int newPosition_X;

    
    public float coins;

    public void Start()
    {
        coins = 0;
        startPosition_X = (int)player.transform.position.x;
    }

    void Update()
    {
        newPosition_X = (int)player.transform.position.x - startPosition_X;

        if (SceneManager.GetActiveScene().name == "(test) Level 0")
        { 
            coins = newPosition_X * 0.3333f;
        }

        else if  (SceneManager.GetActiveScene().name == "(test) Level 1")
        {
            coins = newPosition_X * 0.3333f * 1.05f;
        }
        
        else if  (SceneManager.GetActiveScene().name == "(test) Level 2")
        {
            coins = newPosition_X * 0.3333f * 1.1f;
        }
        
        else if  (SceneManager.GetActiveScene().name == "(test) Level 3")
        {
            coins = newPosition_X * 0.3333f * 1.15f;
        }
        
        else if  (SceneManager.GetActiveScene().name == "(test) Level 4")
        {
            coins = newPosition_X * 0.3333f * 1.2f;
        }
        
        coins = (int)coins;
    }
}
