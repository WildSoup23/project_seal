using UnityEngine;

public class PlayerControles : MonoBehaviour
{
    [SerializeField]
    private Transform transform;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = new Quaternion(transform.rotation.x)
        }
    }
}
