using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        this.gameObject.transform.position = new Vector3(
            player.position.x, 
            this.gameObject.transform.position.y,
            this.gameObject.transform.position.z);
    }
}
