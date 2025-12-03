using UnityEngine;
using UnityEngine.SceneManagement;

public class GetNextScene : MonoBehaviour
{
    private GameObject nextScene;
    public string sceneName;
    
    void Start()
    {
        sceneName = "(test) Level 0";

        if (GameObject.FindGameObjectWithTag("NextScene") == true)
        {
            nextScene = GameObject.FindGameObjectWithTag("NextScene");
            sceneName = nextScene.GetComponent<NextLevel>().nextSceneName;
            Destroy(nextScene);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
