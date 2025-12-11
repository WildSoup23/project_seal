using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("A value that decreases the players speed when colliding with the bird, higher values mean greater speed lose.")]
    [SerializeField] private float speedDecrease;
    public float SPEED_DECREASE
    {
        get { return speedDecrease; }
    }
}
