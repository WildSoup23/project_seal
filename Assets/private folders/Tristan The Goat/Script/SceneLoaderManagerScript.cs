using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class SceneLoaderManagerScript : MonoBehaviour
{
    // Refrences
    [Header("Refrences")]
    [Tooltip("The gameobject of an settings panel")]
    [SerializeField] private GameObject settings_panel;
    [Tooltip("The gameobject of an pause screen")]
    [SerializeField] private GameObject pause_screen;
    [Tooltip("The animtor that controlls fade in and out")]
    [SerializeField] private Animator anim;

    // Returns the name of the current loaded scene via a string.
    public string GetCurrentScene()
    {
        string sceneName;
        sceneName = SceneManager.GetActiveScene().name;
        return sceneName;
    }
    // Loads the scene based on the string input
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
    // Reloads the currently loaded scene
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GetCurrentScene());
    }
    // Creates a new save file and loads the first level
    public void NewGame()
    {
        Time.timeScale = 1f;

        File.Delete(@"c:\temp\test.txt"); // Ensures that we write to a blank file
        
        using (StreamWriter sw = File.AppendText(@"c:\temp\test.txt"))
        {
            sw.WriteLine("0"); // Samlade Pengar
            sw.WriteLine("0"); // Max Speed
            sw.WriteLine("0"); // Acceleration
            sw.WriteLine("0"); // Diving Speed
            sw.WriteLine("1"); // Pengar
            sw.WriteLine("(test) Level 0");
        } 
        
        // TODO: ta bort (test) sen
        // Tillägg av Anton ---------------------------------------------- :)
        LoadScene("(test) Cutscenes");
    }
    // Loads a scene based on how far the player has progress in the game.
    public void ContinueGameOnLoad()
    {
        Time.timeScale = 1f;
        
        // Tillägg av Anton ---------------------------------------------- :)
        LoadScene(File.ReadLines(@"c:\temp\test.txt").Last());
    }
    // Quits the game and closes the application
    public void Quit()
    {
        Application.Quit();
    }

    // Toggles Settings panel on and off
    public void ToggleSettings()
    {
        if (settings_panel.activeSelf)
        {
            settings_panel.SetActive(false);
        }
        else
        {
            settings_panel.SetActive(true);
        }
    }

    public void TogglePause()
    {
        if (pause_screen.activeSelf)
        {
            pause_screen.SetActive(false);
            settings_panel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pause_screen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Test()
    {
        Time.timeScale = 1f;
        pause_screen.SetActive(false);
        anim.SetTrigger("fade_in");
        Invoke("ReloadScene",0.9f);
    }

    private void Update()
    {
        // If player presses escape then open/close pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
