using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    private const string path = @"c:\temp\test.txt";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Directory.CreateDirectory(@"c:\temp");
    }

    public void SaveCoins(CoinsCollected coins)
    {
        int oldAmount = 0;
        int newAmount = coins.coins;
        
        if (File.Exists("c:/temp/test.txt"))
        {
            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                string parsed = line.Trim();
                
                /*
                if (parsed.Length <= 0)
                {
                    continue;
                }
                */

                oldAmount = int.Parse(parsed);
            }
        }

        newAmount += oldAmount;

        List<string> lines = new List<string>();
        
        foreach (string line in File.ReadLines(path, Encoding.UTF8))
        {
            string parsed = line.Trim();
            if (parsed == File.ReadLines(path).First())
            {
                continue;
            }

            lines.Add(parsed);
        }
        
        File.Delete(path); // Ensures that we write to a blank file
        
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(newAmount);
        }
    }
}
