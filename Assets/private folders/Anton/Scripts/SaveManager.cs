using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public float addedAmount;
    public float newAmount;

    private TheKeeper keeper;
    
    private const string path = @"c:\temp\test.txt";

    [SerializeField] private Upgrade_Menu_Script upgrades;

    [SerializeField] private bool willSave;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (willSave) 
            Directory.CreateDirectory(@"c:\temp");
    }

    public void SaveCoins(CoinsCollected coins)
    {
        keeper = GameObject.FindGameObjectWithTag("TheKeeper").GetComponent<TheKeeper>();
        
        if (willSave)
        {
            int oldAmount = 0;
            newAmount = coins.coins;

            oldAmount = (int)keeper.money;
            /*
            // Gets the old money amount
            if (File.Exists("c:/temp/test.txt"))
            {
                foreach (string line in File.ReadLines(path, Encoding.UTF8))
                {
                    string parsed = line.Trim();
                    oldAmount = int.Parse(parsed);
                    break;
                }
            
            }
            */

            addedAmount = newAmount;
            newAmount += oldAmount;
            

            // File.Delete(path); // Ensures that we write to a blank file
            
            keeper.money = newAmount;
            keeper.speed = upgrades.speed_upgrade;
            keeper.accel = upgrades.acceleration_upgrade;
            keeper.dive = upgrades.dive_speed_upgrade;
            keeper.def = upgrades.defense_upgrade;
            keeper.level = SceneManager.GetActiveScene().name;
            
            /*
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newAmount);
                sw.WriteLine(upgrades.speed_upgrade);
                sw.WriteLine(upgrades.acceleration_upgrade);
                sw.WriteLine(upgrades.dive_speed_upgrade);
                sw.WriteLine(upgrades.defense_upgrade);
                sw.WriteLine(SceneManager.GetActiveScene().name);
            } 
            */ 
        }
    }
}
