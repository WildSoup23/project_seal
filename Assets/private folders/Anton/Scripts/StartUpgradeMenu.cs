using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpgradeMenu : MonoBehaviour
{
    public static StartUpgradeMenu instance;
    public bool willStart;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "(test) Cutscenes")
        {
            Destroy(gameObject);
        }
        
        if (SceneManager.GetActiveScene().name == "(test) StartMenu")
        {
            Destroy(gameObject);
        }
    }

    public void UpgradeMenuWillStart()
    {
        DontDestroyOnLoad(gameObject);
        willStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
