using JetBrains.Annotations;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Turorial_Script : MonoBehaviour
{
    private bool hasPlayed = false;
    public bool hasDied = false;
    private GameObject panel;
    private GameObject panel2;
    private GameObject panel3;
    private const string path = @"c:\temp\tutorial_test.txt";
    private Rigidbody2D rb;

    private void Start()
    {
        if (File.Exists(path))
        {
            hasPlayed = bool.Parse(File.ReadLines(path).First());
            hasDied = bool.Parse(File.ReadLines(path).Last());
        }
        
        panel = transform.Find("the panel").gameObject;
        panel2 = transform.Find("the panel2").gameObject;
        panel3 = transform.Find("the panel3").gameObject;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        if (hasPlayed)
        {
            panel.SetActive(false);
        }
        else
        {
            rb.simulated = false;
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (!hasPlayed && panel.activeInHierarchy)
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

        if(!hasDied && panel2.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                panel2.SetActive(false);
                panel3.SetActive(true);
            }
        }
        else if (!hasDied && panel3.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasDied = true;
                panel3.SetActive(false);
                SaveData();
            }
        }

    }

    public void ActiavteDeathTutorial()
    {
        if (!hasDied)
        {
            panel2.SetActive(true);
        }
    }

    private void SaveData()
    {
        const string path = @"c:\temp\tutorial_test.txt";

        File.Delete(path); // Ensures that we write to a blank file

        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(hasPlayed);
            sw.WriteLine(hasDied);
        }
    }
}
