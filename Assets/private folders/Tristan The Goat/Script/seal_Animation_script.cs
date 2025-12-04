using UnityEngine;

public class seal_Animation_script : MonoBehaviour
{
    private Vector2 direction;
    private PlayerControles player;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControles>();
        animator = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = player.GetComponent<Rigidbody2D>().linearVelocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


}
