using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Menu_Script : MonoBehaviour
{
    // Variables
    [Header("Variables")]
    [Header("Speed")]
    [SerializeField] private float speed_upgrade;
    [SerializeField] private float max_speed_upgrade;
    [SerializeField] private float speed_upgrade_cost;
    [SerializeField] private float speed_upgrade_cost_increase;
    [Header("Acceleration")]
    [SerializeField] private float acceleration_upgrade;
    [SerializeField] private float max_acceleration_upgrade;
    [SerializeField] private float acceleration_upgrade_cost;
    [SerializeField] private float acceleration_upgrade_cost_increase;
    [Header("Dive speed")]
    [SerializeField] private float dive_speed_upgrade;
    [SerializeField] private float max_dive_speed_upgrade;
    [SerializeField] private float dive_speed_upgrade_cost;
    [SerializeField] private float dive_speed_upgrade_cost_increase;
    [Header("Money gain")]
    [SerializeField] private float money_gain_upgrade;
    [SerializeField] private float max_money_gain_upgrade;
    [SerializeField] private float money_gain_upgrade_cost;
    [SerializeField] private float money_gain_upgrade_cost_increase;

    [Header("Money")]
    [SerializeField] private float money;

    // Refrences
    [Header("Refrences")]
    [SerializeField] private GameObject upgrade_panel;
    [Header("Speed")]
    [SerializeField] private Slider speed_slider;
    [SerializeField] private Slider speed_slider2;
    [SerializeField] private GameObject speed_panel;
    [Header("Acceleration")]
    [SerializeField] private Slider acceleration_slider;
    [SerializeField] private Slider acceleration_slider2;
    [SerializeField] private GameObject acceleration_panel;
    [Header("Dive speed")]
    [SerializeField] private Slider dive_speed_slider;
    [SerializeField] private Slider dive_speed_slider2;
    [SerializeField] private GameObject dive_speed_panel;
    [Header("Money gain")]
    [SerializeField] private Slider money_slider;
    [SerializeField] private Slider money_slider2;
    [SerializeField] private GameObject money_gain_panel;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI money_txt;

    private GameObject player;
    private GameObject ui_elements;

    // Get the player
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ui_elements = transform.Find("UI elements").gameObject;
        Debug.Log(ui_elements);
    }

    // Update is called once per frame
    void Update()
    {
        speed_slider.value = speed_upgrade / max_speed_upgrade;
        speed_slider2.value = speed_slider.value;
        acceleration_slider.value = acceleration_upgrade / max_acceleration_upgrade;
        acceleration_slider2.value = acceleration_slider.value;
        dive_speed_slider.value = dive_speed_upgrade / max_dive_speed_upgrade;
        dive_speed_slider2.value = dive_speed_slider.value;
        money_slider.value = money_gain_upgrade / max_money_gain_upgrade;
        money_slider2.value = money_slider.value;

        money_txt.text = $"{money}";
    }

    public void OpenSpeedUpgrade()
    {
        upgrade_panel.SetActive(true);
        speed_panel.SetActive(true);
    }

    public void UpgradeSpeed()
    {
        if(speed_upgrade < max_speed_upgrade)
        {
            if(money >= speed_upgrade_cost)
            {
                speed_upgrade++;
                money -= speed_upgrade_cost;
                speed_upgrade_cost = Mathf.Round(speed_upgrade_cost * speed_upgrade_cost_increase);

                if(player != null)
                {

                }
            }
        }
    }

    public void OpenAccelerationUpgrade()
    {
        upgrade_panel.SetActive(true);
        acceleration_panel.SetActive(true);
    }

    public void UpgradeAcceleration()
    {
        if (acceleration_upgrade < max_acceleration_upgrade)
        {
            if (money >= acceleration_upgrade_cost)
            {
                acceleration_upgrade++;
                money -= acceleration_upgrade_cost;
                acceleration_upgrade_cost = Mathf.Round(acceleration_upgrade_cost * acceleration_upgrade_cost_increase);

                if (player != null)
                {

                }
            }
        }
    }

    public void OpenDiveSpeedUpgrade()
    {
        upgrade_panel.SetActive(true);
        dive_speed_panel.SetActive(true);
    }

    public void UpgradeDiveSpeed()
    {
        if (dive_speed_upgrade < max_dive_speed_upgrade)
        {
            if (money >= dive_speed_upgrade_cost)
            {
                dive_speed_upgrade++;
                money -= dive_speed_upgrade_cost;
                dive_speed_upgrade_cost = Mathf.Round(dive_speed_upgrade_cost * dive_speed_upgrade_cost_increase);

                if (player != null)
                {

                }
            }
        }
    }
    public void OpenMoneyGainUpgrade()
    {
        upgrade_panel.SetActive(true);
        money_gain_panel.SetActive(true);
    }

    public void UpgradeMoneyGain()
    {
        if (money_gain_upgrade < max_money_gain_upgrade)
        {
            if (money >= money_gain_upgrade_cost)
            {
                money_gain_upgrade++;
                money -= money_gain_upgrade_cost;
                money_gain_upgrade_cost = Mathf.Round(money_gain_upgrade_cost * money_gain_upgrade_cost_increase);

                if (player != null)
                {

                }
            }
        }
    }

    public void ClosePanel()
    {
        upgrade_panel.SetActive(false);
        speed_panel.SetActive(false);
        acceleration_panel.SetActive(false);
        dive_speed_panel.SetActive(false);
        money_gain_panel.SetActive (false);
    }

    public void Run()
    {
        ui_elements.SetActive(false);
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
