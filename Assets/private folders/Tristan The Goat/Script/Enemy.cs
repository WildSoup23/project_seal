using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("A value that decreases the players speed when colliding with the bird, higher values mean greater speed lose.")]
    [Range(0,1)]
    [SerializeField] private float speedDecrease;
    public float SPEED_DECREASE
    {
        get { return speedDecrease; }
    }
}
