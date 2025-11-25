using UnityEngine;

public class PlayerControles : MonoBehaviour
{
    [SerializeField]
    private Transform transform;
    
    [SerializeField]
    private float rotateAmount;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(0, 0, rotateAmount);
        }
    }
}
