using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BirdScript : Enemy
{
    // Variables
    [Header("Variables")]
    [Tooltip("The speed at wich the bird flies at, higher value means faster.")]
    [SerializeField] private float flySpeed;
    [Tooltip("The range at wich the player needs to be in for the bird to move.")]
    [SerializeField] private float activationRange;
    
    // Refrences
    [Header("Refrences")]
    [Tooltip("If a particle system if refrenced, gets played on collision with player.")]
    [SerializeField] private ParticleSystem feather_burst_effect;
    private Rigidbody2D rb;
    private GameObject player;
    private Animator anim;

    // On start looks for an rigidbody2d component and a object with the player tag.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per fixed frame
    private void FixedUpdate()
    {
        // Gets the distance between the player and the bird
        float range;
        range = Vector3.Distance(transform.position, player.transform.position);

        // If the player is closer than the acrivationRange than the birds move.
        if(range < activationRange)
        {
            rb.linearVelocityX = flySpeed * -1 * Time.fixedDeltaTime;
        }
        // If not than reduce the speed of the bird untill it doesent move.
        else if(range > activationRange && Mathf.Sqrt(Mathf.Pow(rb.linearVelocityX,2)) >0) 
        {
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX - (flySpeed * Time.fixedDeltaTime),0,10000);
        }
    }

    // On trigger collsion with player plays an particle effect if there is one refrenced, also plays an animaion if there is one refrenced.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(feather_burst_effect != null)
            {
                feather_burst_effect.Play();
            }
            if(anim != null)
            {
                anim.SetTrigger("Hit");
            }
        }
    }

    // Draws gizmos so that its easier to see the range and distance of the birds and player.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, activationRange);

        if(player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}
