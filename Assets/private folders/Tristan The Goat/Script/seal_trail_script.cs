using UnityEngine;

public class seal_trail_script : MonoBehaviour
{
    // Variables 
    [SerializeField] private float trail_width;
    [SerializeField] private Color trail_color;

    // Refrence
    private TrailRenderer trailRenderer;
    private Rigidbody2D playerrb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        playerrb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trailRenderer.startWidth = trail_width;
        // Create a new gradient
        Gradient gradient = new Gradient();

        // Set your custom colors + alphas
        gradient.colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(trail_color, 0f)
        };

        float alpha = playerrb.linearVelocity.magnitude;

        gradient.alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(alpha/200, 0f)
        };
        trailRenderer.colorGradient = gradient;
    }
}
