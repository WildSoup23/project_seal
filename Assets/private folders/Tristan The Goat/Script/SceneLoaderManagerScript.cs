using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManagerScript : MonoBehaviour
{
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
        SceneManager.LoadScene(sceneName);
    }
    // Reloads the currently loaded scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }
    // Creates a new save file and loads the first level
    public void NewGame()
    {

    }
    // Loads a scene based on how far the player has progress in the game.
    public void ContinueGameOnLoad()
    {

    }
    // Quits the game and closes the application
    public void Quit()
    {
        Application.Quit();
    }
}
