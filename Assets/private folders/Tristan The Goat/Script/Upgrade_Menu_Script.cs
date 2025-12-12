using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Upgrade_Menu_Script : MonoBehaviour
{
    // Variables
    [Header("Variables")]
    [Header("Speed")]
    public float speed_upgrade;
    [SerializeField] private float max_speed_upgrade;
    [SerializeField] private float speed_upgrade_cost;
    [SerializeField] private float speed_upgrade_cost_increase;
    [SerializeField] private string speed_upgrade_txt;
    [SerializeField] private TextMeshProUGUI speed_upgrade_text;
    
    [Header("Acceleration")]
    public float acceleration_upgrade;
    [SerializeField] private float max_acceleration_upgrade;
    [SerializeField] private float acceleration_upgrade_cost;
    [SerializeField] private float acceleration_upgrade_cost_increase;
    [SerializeField] private string acceleration_upgrade_txt;
    [SerializeField] private TextMeshProUGUI acceleration_upgrade_text;

    [Header("Dive speed")]
    public float dive_speed_upgrade;
    [SerializeField] private float max_dive_speed_upgrade;
    [SerializeField] private float dive_speed_upgrade_cost;
    [SerializeField] private float dive_speed_upgrade_cost_increase;
    [SerializeField] private string dive_speed_upgrade_txt;
    [SerializeField] private TextMeshProUGUI dive_speed_upgrade_text;

    [Header("Defense")]
    public float defense_upgrade;
    [SerializeField] private float max_defense_upgrade;
    [SerializeField] private float defense_upgrade_cost;
    [SerializeField] private float defense_upgrade_cost_increase;
    [SerializeField] private string defense_upgrade_txt;

    [Header("Money")]
    [SerializeField] private float money;

    // Refrences
    [Header("Refrences")]
    [Header("Sliders")]
    [SerializeField] private Slider speed_slider;
    [SerializeField] private Slider acceleration_slider;
    [SerializeField] private Slider dive_speed_slider;
    [SerializeField] private Slider money_slider;

    [Header("Upgrade panel")]
    [SerializeField] private GameObject upgrade_panel;
    [SerializeField] private Slider upgrade_slider;
    [SerializeField] private TextMeshProUGUI top_txt;
    [SerializeField] private TextMeshProUGUI upgrade_txt;
    [SerializeField] private TextMeshProUGUI upgrade_cost_txt;
    [SerializeField] private TextMeshProUGUI upgrade_value_txt;
    private int menu_identifier;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI money_txt;
    
    [Header("Saving")]
    [SerializeField] private bool willSaveAndLoad;

    [SerializeField] private GameObject player;
    private PlayerControles pc;
    [SerializeField] public GameObject ui_elements; // Ändrad av Anton :)
    [SerializeField] private StartUpgradeMenu willStart;


    private const string path = @"c:\temp\test.txt";
    

    // Get the player
    void Start()
    {
        pc = player.GetComponent<PlayerControles>();
        
        willStart = StartUpgradeMenu.instance;
        Debug.Log(willStart.willStart);
        
        if (willStart.willStart)
        {
            ui_elements.SetActive(true);
            willStart.willStart = false;
        }
        
        if (ui_elements.activeSelf)
        {
            player.GetComponent<Rigidbody2D>().simulated = false;
        }
        
        if (willSaveAndLoad)
        {
            if (File.Exists("c:/temp/test.txt"))
            {
                int playerAttribute = -1;
                
                money = float.Parse(File.ReadLines(path).First());
                
                foreach (string line in File.ReadLines(path, Encoding.UTF8))
                {
                    string parsed = line.Trim();
                
                    if (parsed == File.ReadLines(path).First())
                    {
                    
                    }

                    else if (playerAttribute == 0)
                    {
                        speed_upgrade = float.Parse(parsed);
                        speed_upgrade_cost = Mathf.Round(speed_upgrade_cost * Mathf.Pow(2, speed_upgrade));
                        
                    }
                
                    else if (playerAttribute == 1)
                    {
                        acceleration_upgrade = float.Parse(parsed);
                        acceleration_upgrade_cost = Mathf.Round(acceleration_upgrade_cost * Mathf.Pow(2, acceleration_upgrade));
                    }
                
                    else if (playerAttribute == 2)
                    {
                        dive_speed_upgrade = float.Parse(parsed);
                        dive_speed_upgrade_cost = Mathf.Round(dive_speed_upgrade_cost * Mathf.Pow(2, dive_speed_upgrade));
                        
                    }
                
                    // TODO: Change into defense upgrade
                    else if (playerAttribute == 3)
                    {
                        // problem
                        defense_upgrade = float.Parse(parsed);
                        defense_upgrade_cost = Mathf.Round(defense_upgrade_cost * Mathf.Pow(2, defense_upgrade - 1));
                        break;
                    }
                
                    playerAttribute++;
                }
            }
        }
        
        
        
        // player = GameObject.FindGameObjectWithTag("Player");
        // ui_elements = transform.Find("UI elements").gameObject;

        speed_slider.value = speed_upgrade / max_speed_upgrade;
        acceleration_slider.value = acceleration_upgrade / max_acceleration_upgrade;
        dive_speed_slider.value = dive_speed_upgrade / max_dive_speed_upgrade;
        money_slider.value = defense_upgrade / max_defense_upgrade;
    }
    
    void Update()
    {
        willStart = StartUpgradeMenu.instance;
        money_txt.text = $"${money}";
        if (speed_upgrade >= max_speed_upgrade)
        {
            speed_upgrade_text.text = "MAX";
        }
        else
        {
            speed_upgrade_text.text = $"Fastest Seal Alive: {speed_upgrade_cost}";
        }

        if (acceleration_upgrade >= max_acceleration_upgrade)
        {
            acceleration_upgrade_text.text = "MAX";
        }
        else
        {
            acceleration_upgrade_text.text = $"On A Roll: {acceleration_upgrade_cost}";
        }

        if (dive_speed_upgrade >= max_dive_speed_upgrade)
        {
            dive_speed_upgrade_text.text = "MAX";
        }
        else
        {
            dive_speed_upgrade_text.text = $"Pinniped Plunge: {dive_speed_upgrade_cost}";
        }

    }

    public void OpenSpeedUpgrade()
    {
        upgrade_panel.SetActive(true);
        menu_identifier = 1;
        upgrade_slider.value = speed_upgrade / max_speed_upgrade;
        upgrade_txt.text = speed_upgrade_txt;
        top_txt.text = "Fastest Seal Alive";
        upgrade_cost_txt.text = $"${speed_upgrade_cost}";
        upgrade_value_txt.text = $"Top speed: {pc.maxVelocity_X * 4}skm/h";

        if(speed_upgrade >= max_speed_upgrade)
        {
            upgrade_cost_txt.text = "MAX";
        }
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
                speed_slider.value = speed_upgrade / max_speed_upgrade;
                upgrade_slider.value = speed_upgrade / max_speed_upgrade;
                upgrade_cost_txt.text = $"${speed_upgrade_cost}";
                upgrade_value_txt.text = $"Top speed: {pc.maxVelocity_X * 4}skm/h";

                if (speed_upgrade >= max_speed_upgrade)
                {
                    upgrade_cost_txt.text = "MAX";
                }
            }
        }
        
    }

    public void OpenAccelerationUpgrade()
    {
        upgrade_panel.SetActive(true);
        menu_identifier = 2;
        upgrade_slider.value = acceleration_upgrade / max_acceleration_upgrade;
        upgrade_txt.text = acceleration_upgrade_txt;
        top_txt.text = "Acceleration";
        upgrade_cost_txt.text = $"${acceleration_upgrade_cost}";
        upgrade_value_txt.text = $"Acceleration: {pc.speedMultiplier * 6}st/s^2";

        if (acceleration_upgrade >= max_acceleration_upgrade)
        {
            upgrade_cost_txt.text = "MAX";
        }
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
                acceleration_slider.value = acceleration_upgrade / max_acceleration_upgrade;
                upgrade_slider.value = acceleration_upgrade / max_acceleration_upgrade;
                upgrade_cost_txt.text = $"${acceleration_upgrade_cost}";
                upgrade_value_txt.text = $"Acceleration: {pc.speedMultiplier * 6}st/s^2";

                if (acceleration_upgrade >= max_acceleration_upgrade)
                {
                    upgrade_cost_txt.text = "MAX";
                }
            }
        }

        
    }

    public void OpenDiveSpeedUpgrade()
    {
        upgrade_panel.SetActive(true);
        menu_identifier = 3;
        upgrade_slider.value = dive_speed_upgrade / max_dive_speed_upgrade;
        upgrade_txt.text = dive_speed_upgrade_txt;
        top_txt.text = "Dive Speed";
        upgrade_cost_txt.text = $"${dive_speed_upgrade_cost}";
        upgrade_value_txt.text = $"Dive speed: {pc.speedMultiplier * 2}st/s^2";

        if (dive_speed_upgrade >= max_dive_speed_upgrade)
        {
            upgrade_cost_txt.text = "MAX";
        }
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
                dive_speed_slider.value = dive_speed_upgrade / max_dive_speed_upgrade;
                upgrade_slider.value = dive_speed_upgrade / max_dive_speed_upgrade;
                upgrade_cost_txt.text = $"${dive_speed_upgrade_cost}";
                upgrade_value_txt.text = $"Dive speed: {pc.speedMultiplier * 2}st/s^2";

                if (dive_speed_upgrade >= max_dive_speed_upgrade)
                {
                    upgrade_cost_txt.text = "MAX";
                }
            }
        }
    }
    public void OpenMoneyGainUpgrade()
    {
        upgrade_panel.SetActive(true);
        menu_identifier = 4;
        upgrade_slider.value = defense_upgrade / max_defense_upgrade;
        upgrade_txt.text = defense_upgrade_txt;
        top_txt.text = "Money Gain";
        upgrade_cost_txt.text = $"${defense_upgrade_cost}";
    }

    public void UpgradeMoneyGain()
    {
        if (defense_upgrade < max_defense_upgrade)
        {
            if (money >= defense_upgrade_cost)
            {
                defense_upgrade++;
                money -= defense_upgrade_cost;
                defense_upgrade_cost = Mathf.Round(defense_upgrade_cost * defense_upgrade_cost_increase);
                money_slider.value = defense_upgrade / max_defense_upgrade;
                upgrade_slider.value = defense_upgrade / max_defense_upgrade;
                upgrade_cost_txt.text = $"${defense_upgrade_cost}";

                if (player != null)
                {

                }
            }
        }
    }

    public void MainUpgrade()
    {
        if (menu_identifier == 1) UpgradeSpeed();
        else if (menu_identifier == 2) UpgradeAcceleration();
        else if (menu_identifier == 3) UpgradeDiveSpeed();
        else if(menu_identifier == 4) UpgradeMoneyGain();
    }

    public void ClosePanel()
    {
        upgrade_panel.SetActive(false);
    }

    public void Run()
    {
        const string path = @"c:\temp\test.txt";

        if (willSaveAndLoad)
        {
            File.Delete(path); // Ensures that we write to a blank file
        
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(money);
                sw.WriteLine(speed_upgrade);
                sw.WriteLine(acceleration_upgrade);
                sw.WriteLine(dive_speed_upgrade);
                sw.WriteLine(defense_upgrade);
                sw.WriteLine(SceneManager.GetActiveScene().name);
            }   
        }
        player.GetComponent<Rigidbody2D>().simulated = true;
        ui_elements.SetActive(false);
        Cursor.visible = false;
        
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
