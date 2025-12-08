using System.Collections.Generic;
using System.Net;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Distance_Meter_Script : MonoBehaviour
{
    // Varibles
    [SerializeField] private float iconSize;


    // Refrences
    [SerializeField] private GameObject startIcon;
    [SerializeField] private GameObject isbergIcon;
    [SerializeField] private GameObject endIcon;
    private List<GameObject> icons = new List<GameObject>();
    private float width;
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

        
        if(isbergIcon != null && startIcon != null && endIcon != null)
        {
            width = slider.gameObject.GetComponent<RectTransform>().rect.width;
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Slope");
            
            foreach (GameObject obj in objectsWithTag)
            {
                GameObject newItem = Instantiate(isbergIcon, transform);
                Vector3 newpos = new Vector3(0, 0, 0);
                newpos.x = (((obj.transform.position.x /
                    (end.position.x - start.position.x)) * width - (width / 2)) + width/10);
                newItem.GetComponent<RectTransform>().localPosition = newpos;
                newItem.transform.SetSiblingIndex(handle_rect.transform.GetSiblingIndex());
                icons.Add(newItem);
            }
            // Start icon
            GameObject startPoint = Instantiate(startIcon, transform);
            Vector3 newpos2 = new Vector3(0-(width/2), 0, 0);
            startPoint.GetComponent<RectTransform>().localPosition = newpos2;
            startPoint.transform.SetSiblingIndex(handle_rect.transform.GetSiblingIndex());
            startPoint.name = "startPoint_icon";
            icons.Add(startPoint);

            // End icon
            GameObject endPoint = Instantiate(endIcon, transform);
            Vector3 newpos3 = new Vector3(width/2, 0, 0);
            endPoint.GetComponent<RectTransform>().localPosition = newpos3;
            endPoint.transform.SetSiblingIndex(handle_rect.transform.GetSiblingIndex());
            endPoint.name = "endPoint_icon";
            icons.Add(endPoint);

        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float distance;
        distance = end.position.x - start.position.x;
        
        slider.value = player.position.x/distance;
        handle_rect.localEulerAngles = new Vector3(0, 0, slider.value * -360);

        UpdateIcons();
    }

    private void UpdateIcons()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Slope");
        width = slider.gameObject.GetComponent<RectTransform>().rect.width;
        int index = 0;


        foreach (var icon in icons)
        {
            if(icon.name == "startPoint_icon")
            {
                Vector3 newpos2 = new Vector3(0 - (width / 2), 0, 0);
                icon.GetComponent<RectTransform>().localPosition = newpos2;
            }
            else if(icon.name == "endPoint_icon")
            {
                Vector3 newpos3 = new Vector3(width / 2, 0, 0);
                icon.GetComponent<RectTransform>().localPosition = newpos3;
            }
            else
            {
                
                Vector3 newpos = new Vector3(0, 0, 0);
                newpos.x = (((objectsWithTag[index].transform.position.x /
                    (end.position.x - start.position.x)) * width - (width / 2)) + width / 10);
                icon.GetComponent<RectTransform>().localPosition = newpos;
            }
            index++;
        }
    }
}
