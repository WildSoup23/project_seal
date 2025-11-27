using UnityEngine;

public class OnEnterEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"You win!!! {Win_Lose_Script.instance}");
            Win_Lose_Script.instance.OnTriggerWin();
        }
    }
}
