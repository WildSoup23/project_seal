using System;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    [SerializeField] private Transform card;
    public bool allowedToFlip = false;
    [SerializeField] private GameObject nextButton;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        if ((card.gameObject.activeSelf && card.rotation.y >= 1))
        {
            nextButton.SetActive(true);
        }
        
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
