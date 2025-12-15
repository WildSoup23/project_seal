using Unity.VisualScripting;
using UnityEngine;

public class PlayerArrowScript : MonoBehaviour
{
    [SerializeField] private Vector2 arrow_min_max_size = new Vector2(0.5f, 3);
    [SerializeField] private float minArrowShowHight;
    [SerializeField] private float arrowGrowSpeed;
     private RectTransform arrowTransform;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrowTransform = transform.Find("arrow").GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > minArrowShowHight)
        {
            // Arrow scale
            float x = Mathf.Clamp(player.transform.position.y / 50,arrow_min_max_size.x, arrow_min_max_size.y);
            arrowTransform.localScale = Vector2.Lerp(arrowTransform.localScale, new Vector2(x, x), arrowGrowSpeed);
        }
        else
        {
            arrowTransform.localScale = Vector2.Lerp(arrowTransform.localScale, new Vector2(0, 0), arrowGrowSpeed);
        }
        // Arrow pos
        Vector2 newpos = Camera.main.WorldToScreenPoint(player.transform.position);
        newpos = GetComponent<RectTransform>().InverseTransformPoint(newpos);
        float scalex = arrowTransform.localScale.x;
        float y = -25 * scalex;
        arrowTransform.localPosition = Vector2.Lerp(arrowTransform.localPosition, new Vector2(newpos.x, arrowTransform.localPosition.y), arrowGrowSpeed);
        arrowTransform.anchoredPosition = Vector2.Lerp(arrowTransform.anchoredPosition, new Vector2(arrowTransform.anchoredPosition.x, y), arrowGrowSpeed);
    }
}
