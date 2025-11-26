using System;
using UnityEngine;

public class PlayerControles : MonoBehaviour
{
    public float changedGravityScale;
    
    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private float rotateAmount;
    
    private bool allowedToRotate;

    private void Awake()
    {
        allowedToRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            allowedToRotate = true;
        }

        else
        {
            allowedToRotate = false;
        }
    }

    void FixedUpdate()
    {
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().linearVelocity);
        
        if (allowedToRotate & gameObject.transform.rotation.z > 0)
        {
            gameObject.transform.Rotate(0, 0, rotateAmount);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = changedGravityScale;
        }

        else
        {
            if ()
            {
                gameObject.transform.Rotate(0, 0, rotateAmount);
            }
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
