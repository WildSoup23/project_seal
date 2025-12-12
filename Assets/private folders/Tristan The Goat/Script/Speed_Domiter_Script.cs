using TMPro;
using UnityEditor;
using UnityEngine;

public class Speed_Domiter_Script : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private TextMeshProUGUI speed_text;
    private Rigidbody2D player_rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = player_rb.linearVelocity.sqrMagnitude / 5;
        Quaternion targetRotation = Quaternion.AngleAxis(45-angle, Vector3.forward);

        _rectTransform.localRotation = Quaternion.Slerp(_rectTransform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

        speed_text.text = $"{Mathf.Round(player_rb.linearVelocity.magnitude * 3)}Skm/h";
    }
}
