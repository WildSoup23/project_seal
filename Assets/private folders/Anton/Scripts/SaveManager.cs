using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
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
        if (willSave)
        {
            int oldAmount = 0;
            float newAmount = coins.coins;
        
            
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
            newAmount += oldAmount;
            

            File.Delete(path); // Ensures that we write to a blank file
            
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newAmount);
                sw.WriteLine(upgrades.speed_upgrade);
                sw.WriteLine(upgrades.acceleration_upgrade);
                sw.WriteLine(upgrades.dive_speed_upgrade);
                sw.WriteLine(upgrades.money_gain_upgrade);
                sw.WriteLine(SceneManager.GetActiveScene().name);
            }  
        }
    }
}
