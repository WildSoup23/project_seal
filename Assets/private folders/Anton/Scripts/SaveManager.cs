using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private const string path = @"c:\temp\test.txt";

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

            List<string> lines = new List<string>();
        
            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                string parsed = line.Trim();
                if (parsed == File.ReadLines(path).First())
                {
                    continue;
                }
                
                if (parsed == File.ReadLines(path).Last())
                {
                    continue;
                }

                lines.Add(parsed);
            }
        
            File.Delete(path); // Ensures that we write to a blank file
        
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newAmount);

                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }

                sw.WriteLine(SceneManager.GetActiveScene().name);
            }  
        }
    }
}
