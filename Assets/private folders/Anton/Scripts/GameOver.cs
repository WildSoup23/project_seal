using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public UnityEvent SaveCoins;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SaveCoins?.Invoke();
            Win_Lose_Script.instance.OnTriggerLose();
        }
    }
}
