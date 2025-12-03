using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextSceneName;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        
        if (SceneManager.GetActiveScene().name == "(test) Level 0")
        {
            nextSceneName = "(test) Level 1";
        }
        
        else if (SceneManager.GetActiveScene().name == "(test) Level 1")
        {
            nextSceneName = "(test) Level 2";
        }
        
        else if (SceneManager.GetActiveScene().name == "(test) Level 2")
        {
            nextSceneName = "(test) Level 3";
        }
        
        else if (SceneManager.GetActiveScene().name == "(test) Level 3")
        {
            nextSceneName = "(test) Level 4";
        }
    }
}
