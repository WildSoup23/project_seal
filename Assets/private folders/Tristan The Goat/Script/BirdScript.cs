using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Variables
    [SerializeField] private float flySpeed;
    [SerializeField] private float speedDecrease;
    public float SPEED_DECREASE
    {
        get {return speedDecrease;}
        set {speedDecrease = value;}
    }

    // Refrences
    private Rigidbody2D rb;
    [SerializeField] private ParticleSystem feather_burst_effect;

    // On start looks for an rigidbody2d component
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per fixed frame
    private void FixedUpdate()
    {
        rb.linearVelocityX = flySpeed * -1 * Time.fixedDeltaTime;
    }

    // On trigger collsion with player plays an particle effect if there is one refrenced.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(feather_burst_effect != null)
            {
                feather_burst_effect.Play();
            }
        }
    }
}
