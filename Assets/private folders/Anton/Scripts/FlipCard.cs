using System;
using TMPro;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    [SerializeField] private Transform card;
    public TextMeshProUGUI cardText;
    public bool allowedToFlip = false;
    public bool allowedToFlipAgain = false;
    public bool flipFirst = true;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private float timer = 3f;

    private Quaternion startRotaion;
    bool timerStart;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        startRotaion = card.rotation;
    }

    private void FixedUpdate()
    {

        if (card.rotation.y >= 0.99)
        {
            timerStart = true;
        }
        
        if ((card.gameObject.activeSelf && timerStart))
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    nextButton.SetActive(true);
                }
            }
        }
        
        if (allowedToFlip)
        {
            Flip();
        }

        if (allowedToFlipAgain)
        {
            FlipAgain();
        }
    }

    public void Flip()
    {
            if (card.rotation.y < 1)
            {
                card.Rotate(0, 2, 0);

                if (card.rotation.y > 0.75f)
                {
                    cardText.color += new Color(-0.0222f, -0.0222f, -0.0222f);
                }
                
                if (card.rotation.y > 0.75f)
                {
                    cardText.color += new Color(0, 0, 0, 1);
                }
            }

            else
            {
                cardText.color = new Color(0, 0, 0);
                allowedToFlip = false;
            }
    }
    
    public void FlipAgain()
    {
        if (card.rotation.y > 0)
        {
            card.Rotate(0, 2, 0);

            if (card.rotation.y < 0.75f)
            {
                cardText.color += new Color(0.0222f, 0.0222f, 0.0222f);
            }
                
            if (card.rotation.y < 0.75f)
            {
                cardText.color += new Color(0, 0, 0, -1);
            }
        }

        else
        {
            cardText.color = new Color(1, 1, 1);
            card.rotation = startRotaion;
            allowedToFlipAgain = false;
        }
    }

    public void Allowed()
    {
        if (flipFirst)
        {
            allowedToFlip = true;
            flipFirst = false;
        }

        else
        {
            allowedToFlipAgain = true;
            flipFirst = true;
        }
    }
}
