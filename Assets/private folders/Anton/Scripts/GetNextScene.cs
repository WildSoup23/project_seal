using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.IO;

public class GetNextScene : MonoBehaviour
{
    public GameObject card;
    public TextMeshProUGUI cardText;
    public GameObject FlipText;
    private GameObject nextScene;
    public string sceneName;
    public bool comicYes;
    public GameObject button;

    [SerializeField] private GameObject comic;
    
    [SerializeField] private Sprite photocard_0;
    [SerializeField] private Sprite photocard_1;
    [SerializeField] private Sprite photocard_2;
    [SerializeField] private Sprite photocard_3;
    [SerializeField] private Sprite photocard_4;
    
    [SerializeField] private GameObject comic1;
    [SerializeField] private GameObject comic2;
    
    
    [SerializeField] private Sprite comic_1;
    [SerializeField] private Sprite comic_2;
    [SerializeField] private Sprite comic_3;
    [SerializeField] private Sprite comic_4;
    [SerializeField] private Sprite comic_5;

    [SerializeField] private RuntimeAnimatorController first1;
    [SerializeField] private RuntimeAnimatorController middle1;
    [SerializeField] private RuntimeAnimatorController finale1;
    
    [SerializeField] private RuntimeAnimatorController first2;
    [SerializeField] private RuntimeAnimatorController middle2;
    [SerializeField] private RuntimeAnimatorController finale2;

    private bool GiveMeButton;
    [SerializeField] private GameObject animThatKeepsPlaying;
    
    void Start()
    {
        sceneName = "(test) Level 0";

        if (GameObject.FindGameObjectWithTag("NextScene") == true)
        {
            nextScene = GameObject.FindGameObjectWithTag("NextScene");
            sceneName = nextScene.GetComponent<NextLevel>().nextSceneName;
            comicYes = nextScene.GetComponent<NextLevel>().comicYes;
        }

        if (!comicYes)
        {
            comic.SetActive(false);
            card.SetActive(true);
            FlipText.SetActive(true);
        
            if (sceneName == "(test) Level 1")
            {
                card.GetComponent<SpriteRenderer>().sprite = photocard_0;
                cardText.text =
                    "Some Penguins weren’t afraid of anything. Not even their King, Skeal III. They had no respect for his rule.";
                nextScene.GetComponent<NextLevel>().comicYes = true;
            }
        
            else if (sceneName == "(test) Level 2")
            {
                card.GetComponent<SpriteRenderer>().sprite = photocard_1;
                cardText.text = "They continued to challenge him, breaking every rule. And every time, he put them in their place.";
                nextScene.GetComponent<NextLevel>().comicYes = true;
            }
        
            else if (sceneName == "(test) Level 3")
            {
                card.GetComponent<SpriteRenderer>().sprite = photocard_2;
                cardText.text = "New rules kept getting made, and the disobedience spread. Skeal III grew frustrated; it wasn’t that hard to not disrupt the snow!";
                nextScene.GetComponent<NextLevel>().comicYes = true;
            }
        
            else if (sceneName == "(test) Level 4")
            {
                card.GetComponent<SpriteRenderer>().sprite = photocard_3;
                cardText.text = "More rules, more repercussions, but nothing changed. Skeal III understood it then; everyone was an enemy";
                nextScene.GetComponent<NextLevel>().comicYes = true;
            }
        
            else if (sceneName == "The End")
            {
                card.GetComponent<SpriteRenderer>().sprite = photocard_4;
                cardText.text = "King Skeal III was not going to back down. He would protect his land, even if it was against its own people.";
                nextScene.GetComponent<NextLevel>().comicYes = true;
            }   
        }
        
        if (comicYes)
        {
            comic.SetActive(true);
            card.SetActive(false);
            FlipText.SetActive(false);
        
            if (sceneName == "(test) Level 1")
            {
                comic1.GetComponent<SpriteRenderer>().sprite = comic_1;
                comic2.GetComponent<SpriteRenderer>().sprite = comic_1;
                comic1.GetComponent<Animator>().SetInteger("EpicNumber", 1);                
                comic2.GetComponent<Animator>().SetInteger("EpicNumber", 1);

            }
        
            else if (sceneName == "(test) Level 2")
            {
                comic1.GetComponent<SpriteRenderer>().sprite = comic_2;
                comic2.GetComponent<SpriteRenderer>().sprite = comic_2;
                comic1.GetComponent<Animator>().SetInteger("EpicNumber", 1);                
                comic2.GetComponent<Animator>().SetInteger("EpicNumber", 1);
            }
        
            else if (sceneName == "(test) Level 3")
            {
                comic1.GetComponent<SpriteRenderer>().sprite = comic_3;
                comic2.GetComponent<SpriteRenderer>().sprite = comic_3;
                comic1.GetComponent<Animator>().SetInteger("EpicNumber", 1);                
                comic2.GetComponent<Animator>().SetInteger("EpicNumber", 1);
            }
        
            else if (sceneName == "(test) Level 4")
            {
                comic1.GetComponent<SpriteRenderer>().sprite = comic_4;
                comic2.GetComponent<SpriteRenderer>().sprite = comic_4;
                comic1.GetComponent<Animator>().SetInteger("EpicNumber", 1);                
                comic2.GetComponent<Animator>().SetInteger("EpicNumber", 1);
            }
        
            else if (sceneName == "The End")
            {
                comic1.GetComponent<SpriteRenderer>().sprite = comic_5;
                comic2.GetComponent<SpriteRenderer>().sprite = comic_5;
                comic1.GetComponent<Animator>().SetInteger("EpicNumber", 2);                
                comic2.GetComponent<Animator>().SetInteger("EpicNumber", 2);
            }   
            
            Destroy(nextScene);
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
