using UnityEngine;
using UnityEngine.UI;

public class Distance_Meter_Script : MonoBehaviour
{
    // Refrences
    private RectTransform handle_rect;
    private Slider slider;
    private Transform start;
    private Transform end;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handle_rect = transform.Find("Handle").GetComponent<RectTransform>();
        slider = GetComponent<Slider>();
        start = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        end = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float distance;
        distance = end.position.x - start.position.x;
        
        slider.value = player.position.x/distance;
        handle_rect.localEulerAngles = new Vector3(0, 0, slider.value * -360);
    }
}
