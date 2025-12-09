using System;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    [SerializeField] private Transform card;
    public bool allowedToFlip = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        card = this.gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (allowedToFlip)
        {
            Flip();
        }
    }

    public void Flip()
    {
            if (card.rotation.y < 1)
            {
                card.Rotate(0, 1, 0);
                Debug.Log(card.rotation.y);
            }

            else
            {
                allowedToFlip = false;
            }
    }

    public void Allowed()
    {
        allowedToFlip = true;
    }
}
