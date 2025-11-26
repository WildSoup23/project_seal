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
        
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().linearVelocity);
        
        if (allowedToSlam_ByKey)
        {
            Debug.Log("OOO");
            gameObject.GetComponent<Rigidbody2D>().gravityScale = changedGravityScale;
        }

        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
