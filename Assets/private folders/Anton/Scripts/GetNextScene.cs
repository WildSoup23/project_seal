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

        if (GameObject.FindGameObjectWithTag("NextScene") == true)
        {
            nextScene = GameObject.FindGameObjectWithTag("NextScene");
            sceneName = nextScene.GetComponent<NextLevel>().nextSceneName;
            Destroy(nextScene);
        }

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
                "The Frightening Penguins weren’t afraid of anything. Not even Skeal III. That led them to their downfall.";
        }
        
        else if (sceneName == "(test) Level 2")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_1;
            cardText.text = "It was a mistake to challenge the King. The Fighting Penguins had no chance against him.";
        }
        
        else if (sceneName == "(test) Level 3")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_2;
            cardText.text = "Even the most obedient can turn traitor. That was the role The Fidgeting Penguins played, and it led to their demise.";
            
        }
        
        else if (sceneName == "(test) Level 4")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_3;
            cardText.text = "Knowledge is dangerous. If you’re worried about what they might know, it’d be better to get rid of them. That was what Skeal III did with The Failing Penguins.";
        }
        
        else if (sceneName == "The End")
        {
            card.GetComponent<SpriteRenderer>().sprite = photocard_4;
            cardText.text = "Keep your friends close, but your enemies closer. That must have been what The Familiar Penguins thought when they went through Skeal III’s belongings.";
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
