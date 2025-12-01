using UnityEngine;
using UnityEngine.Events;

public class OnEnterEnd : MonoBehaviour
{
    public UnityEvent SaveCoins; // Tillägg av Anton :)
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"You win!!! {Win_Lose_Script.instance}");
            SaveCoins?.Invoke(); // Tillägg av Anton :)
            Win_Lose_Script.instance.OnTriggerWin();
        }
    }
}
