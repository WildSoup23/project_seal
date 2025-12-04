using UnityEngine;
using UnityEngine.SceneManagement;

public class GetNextScene : MonoBehaviour
{
    public GameObject card;
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

        if (sceneName == "(test) Level 1")
        {
            card.SetActive(true);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
