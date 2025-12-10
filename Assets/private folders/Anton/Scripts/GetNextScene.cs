using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetNextScene : MonoBehaviour
{
    public GameObject card;
    public TextMeshProUGUI cardText;
    public GameObject FlipText;
    private GameObject nextScene;
    public string sceneName;
    public GameObject button;

    
    [SerializeField] private Sprite photocard_0;
    [SerializeField] private Sprite photocard_1;
    [SerializeField] private Sprite photocard_2;
    [SerializeField] private Sprite photocard_3;
    [SerializeField] private Sprite photocard_4;
    
    void Start()
    {
        sceneName = "(test) Level 0";

        if (GameObject.FindGameObjectWithTag("NextScene") == true)
        {
            nextScene = GameObject.FindGameObjectWithTag("NextScene");
            sceneName = nextScene.GetComponent<NextLevel>().nextSceneName;
            Destroy(nextScene);
        }

        if (sceneName != "(test) Level 0")
        {
            card.SetActive(true);
            FlipText.SetActive(true);
        }
        
        if (sceneName == "(test) Level 0")
        {
            button.SetActive(true);
        }
        
        if (sceneName == "(test) Level 1")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_0;
            cardText.text =
                "The Frightening Penguins were not afraid of anything. " +
                "Not even The King, Skeal III. They lived for the thrill of pushing limits. " +
                "One day, they went too far. Everyone knew that hot tubs were forbidden. " +
                "They ruined the fresh, cold air.";
        }
        
        else if (sceneName == "(test) Level 2")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_1;
            cardText.text = "Insert text here :)";
        }
        
        else if (sceneName == "(test) Level 3")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_2;
            cardText.text = "Insert text here :)";
            
        }
        
        else if (sceneName == "(test) Level 4")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_3;
            cardText.text = "Insert text here :)";
        }
        
        else if (sceneName == "The End")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_4;
            cardText.text = "Insert text here :)";
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
