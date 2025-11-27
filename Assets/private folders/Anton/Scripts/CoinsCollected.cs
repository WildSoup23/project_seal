using System;
using UnityEngine;

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
        coins = newPosition_X * coinMultiplier;
    }
}
