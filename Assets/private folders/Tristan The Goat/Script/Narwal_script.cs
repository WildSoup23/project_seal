using Unity.Mathematics;
using UnityEngine;

public class Narwal_script : Enemy
{
    // Variables
    [SerializeField] private float launchSpeed;
    [SerializeField] private float launchAngle;
    [SerializeField] private int resoultion;
    private bool hasLuanched = false;

    // Refrences 
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle-90);
        }
    }

    public void Launch()
    {
        float rad = launchAngle * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        rb.simulated = true;
        rb.linearVelocity = direction * launchSpeed;
        hasLuanched = true;
        Debug.Log("launched");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        float rad = launchAngle * Mathf .Deg2Rad;
        Vector2 startPos = transform.position;
        Vector2 startVel = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * launchSpeed;

        Vector2 prevPoint = startPos;

        for(int i=1; i <= resoultion; i++)
        {
            float t = i * 0.1f;

            Vector2 newPoint = startPos + 
                startVel * t +
                0.5f * new Vector2(0, Physics2D.gravity.y) * t * t;

            Gizmos.DrawLine(prevPoint, newPoint);
            prevPoint = newPoint;
        }

        Gizmos.color = Color.green;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        DrawBoxCollider(box);
    }

    void DrawBoxCollider(BoxCollider2D box)
    {
        Vector3 size = new Vector3(box.size.x, box.size.y, 0);
        Vector3 offset = (Vector3)box.offset;

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(offset, size);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasLuanched)
            {
                Launch();
            }
        }
    }

}
