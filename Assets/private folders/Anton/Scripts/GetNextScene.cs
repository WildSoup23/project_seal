using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
    public GameObject restartButton;

    [SerializeField] private GameObject comic;
    
    [SerializeField] private Sprite photocard_0;
    [SerializeField] private Sprite photocard_1;
    [SerializeField] private Sprite photocard_2;
    [SerializeField] private Sprite photocard_3;
    [SerializeField] private Sprite photocard_4;

    private bool GiveMeButton;
    [SerializeField] private GameObject animThatKeepsPlaying;
    
    void Start()
    {
        sceneName = "(test) Level 0";

        if (sceneName != "(test) Level 0")
        {
            comic.SetActive(false);
            card.SetActive(true);
            FlipText.SetActive(true);
        }
        
        if (sceneName == "(test) Level 1")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_0;
            cardText.text =
                "Some Penguins weren’t afraid of anything. Not even their King, Skeal III. They had no respect for his rule.";
        }
        
        else if (sceneName == "(test) Level 2")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_1;
            cardText.text = "They continued to challenge him, breaking every rule. And every time, he put them in their place.";
        }
        
        else if (sceneName == "(test) Level 3")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_2;
            cardText.text = "New rules kept getting made, and the disobedience spread. Skeal III grew frustrated; it wasn’t that hard to not disrupt the snow!";
            
        }
        
        else if (sceneName == "(test) Level 4")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_3;
            cardText.text = "More rules, more repercussions, but nothing changed. Skeal III understood it then; everyone was an enemy";
        }
        
        else if (sceneName == "The End")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_4;
            cardText.text = "King Skeal III was not going to back down. He would protect his land, even if it was against its own people.";
        }
        
        if (GameObject.FindGameObjectWithTag("NextScene") == true)
        {
            nextScene = GameObject.FindGameObjectWithTag("NextScene");
            sceneName = nextScene.GetComponent<NextLevel>().nextSceneName;
            
            if (comic.activeSelf)
            {
                Destroy(nextScene);
            }
        }
    }

    private void Update()
    {
        if (comic.activeSelf && !GiveMeButton &&
            comic.GetComponentInChildren<Animator>().
                GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            button.SetActive(true);
            animThatKeepsPlaying.SetActive(false);
            GiveMeButton = true;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
