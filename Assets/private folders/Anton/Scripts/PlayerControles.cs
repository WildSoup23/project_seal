using System;
using UnityEngine;

public class PlayerControles : MonoBehaviour
{
    public float changedGravityScale;
    
    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private float rotateAmount;
    
    private bool allowedToSlam_ByKey;
    private bool allowedToSlam_ByVelocity;
    private bool allowedToAccelerate;
    
    public float maxVelocity_X;
    public float speedMultiplier;

    private void Awake()
    {
        allowedToSlam_ByKey = false;
        allowedToSlam_ByVelocity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            allowedToSlam_ByKey = true;
        }

        else
        {
            allowedToSlam_ByKey = false;
        }
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>().linearVelocity.x > maxVelocity_X)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(maxVelocity_X,
                gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
        }
        
        // Debug.Log(gameObject.GetComponent<Rigidbody2D>().linearVelocity);
        
        if (allowedToSlam_ByKey)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = changedGravityScale;

            if (allowedToAccelerate)
            {
                Debug.Log("accelerate");
                gameObject.GetComponent<Rigidbody2D>().linearVelocity *= new Vector2(speedMultiplier, 1);
            }        
        }

        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slope"))
        {
            Debug.Log("Entered");
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
            
            allowedToAccelerate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slope"))
        {
            Debug.Log("Exited");
            allowedToAccelerate = false;
        }
    }
}
