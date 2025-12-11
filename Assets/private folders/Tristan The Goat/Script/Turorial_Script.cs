using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Turorial_Script : MonoBehaviour
{
    private bool hasPlayed = false;
    private GameObject panel;
    private const string path = @"c:\temp\tutorial_test.txt";
    private Rigidbody2D rb;

    private void Start()
    {
        if (File.Exists(path))
        {
            hasPlayed = bool.Parse(File.ReadLines(path).First());
        }
        
        panel = transform.Find("the panel").gameObject;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        if (hasPlayed)
        {
            panel.SetActive(false);
        }
        else
        {
            rb.simulated = false;
        }
            
    }

    void Update()
    {
        if (!hasPlayed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasPlayed = true;
                panel.SetActive(false);
                SaveData();
                Time.timeScale = 1f;
                rb.simulated = true;
            }
        }
    }

    private void SaveData()
    {
        const string path = @"c:\temp\tutorial_test.txt";

        File.Delete(path); // Ensures that we write to a blank file

        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(hasPlayed);
        }
    }
}
