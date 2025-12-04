using UnityEngine;

public class New_Camera_Script : MonoBehaviour
{
    // Variables
    [Header("Variables")]
    [Tooltip("The speed at wich the camera will follow the player and zoom, higher values means faster.")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float followSpeed;
    [Tooltip("Camera y pos offset")]
    [SerializeField] private float cameraYOffset;
    [SerializeField] private float cameraYMin;

    // Refrences
    private Camera cm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets main camera in scene
        cm = Camera.main; 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Moves the camera if the player goes far right enough
        if (transform.position.x > cm.transform.position.x)
        {
            float a = cm.transform.position.x;
            float b = transform.position.x;
            cm.transform.position = Vector3.Lerp(
                new Vector3(a,cm.transform.position.y, cm.transform.position.z), 
                new Vector3(b, cm.transform.position.y, cm.transform.position.z), 
                followSpeed);
        }

        // The cameras zoom and y pos based on player y pos.
        if (cm.orthographic)
        {
            cm.orthographicSize = Mathf.Clamp(transform.position.y + Mathf.Sqrt(Mathf.Pow(cameraYOffset, 2)), 6, 9999);
            cm.transform.position = Vector3.Lerp(
                new Vector3(cm.transform.position.x, cm.transform.position.y, cm.transform.position.z),
                new Vector3(cm.transform.position.x, Mathf.Clamp(cm.orthographicSize + cameraYOffset, cameraYMin, 9999), cm.transform.position.z),
                followSpeed * 2);
        }
        else
        {
            cm.fieldOfView = Mathf.Clamp(70 + transform.position.y * 2 + Mathf.Sqrt(Mathf.Pow(cameraYOffset, 2)), 70, 9999);
            cm.transform.position = Vector3.Lerp(
                new Vector3(cm.transform.position.x, cm.transform.position.y, cm.transform.position.z),
                new Vector3(cm.transform.position.x, Mathf.Clamp(cm.fieldOfView / 9 + cameraYOffset, cameraYMin, 9999), cm.transform.position.z),
                followSpeed * 2);
        } 
    }
}
