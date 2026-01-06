using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Win_Lose_Script : MonoBehaviour
{
    // Refrences 
    [SerializeField] public GameObject win_lose_panel;
    [SerializeField] private List<Sprite> images = new List<Sprite>();
    [SerializeField] private List<Sprite> images2 = new List<Sprite>();
    [SerializeField] private Image imageToChange;
    [SerializeField] private Image imageToChange2;
    [SerializeField] public GameObject continue_btn;
    [SerializeField] private GameObject retrty_btn;
    [SerializeField] private GameObject upgrade_btn;
    [SerializeField] private GameObject menu_btn;

    [SerializeField] private TextMeshProUGUI money_gained_txt;
    [SerializeField] private TextMeshProUGUI total_money_txt;
    [SerializeField] private GameObject tut;

    public static Win_Lose_Script instance;

    private bool hasWon = false;
    private Rigidbody2D player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }

    public void OnTriggerLose()
    {
        if (!hasWon)
        {
            win_lose_panel.SetActive(true);

            imageToChange.sprite = images[0];
            imageToChange2.sprite = images2[0];

            retrty_btn.SetActive(true);
            continue_btn.SetActive(false);
            menu_btn.SetActive(true);
            upgrade_btn.SetActive(true);

            player.linearVelocity = new Vector2(0, 0);
            player.simulated = false;

            Cursor.visible = true;
            DisplayMoney();

            if(tut != null)
            {
                tut.GetComponent<Turorial_Script>().ActiavteDeathTutorial();
            }

        }
    }

    public void OnTriggerWin()
    {
        hasWon = true;
        win_lose_panel.SetActive(true);

        imageToChange.sprite = images[1];
        imageToChange2.sprite = images2[1];

        continue_btn.SetActive(true);
        retrty_btn.SetActive(false);
        menu_btn.SetActive(false);
        upgrade_btn.SetActive(false);

        player.linearVelocity = new Vector2(0, 0);
        player.simulated = false;

        Cursor.visible = true;
        DisplayMoney();
    }

    private void DisplayMoney()
    {
        // Display money shit here
        SaveManager playerMoney = GameObject.FindGameObjectWithTag("Player").GetComponent<SaveManager>();
        money_gained_txt.text = "You earned: " + playerMoney.addedAmount;
        total_money_txt.text = "Total amount: " + playerMoney.newAmount;
    }

    public void ShopButton()
    {
        StartUpgradeMenu.instance.UpgradeMenuWillStart();
    }
}
