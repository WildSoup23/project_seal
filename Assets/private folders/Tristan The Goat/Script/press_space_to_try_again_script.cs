using UnityEngine;

public class press_space_to_try_again_script : MonoBehaviour
{
    private GameObject win_lose;
    private GameObject upgrade_menu;
    private GameObject pause;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        win_lose = GameObject.FindAnyObjectByType<Win_Lose_Script>().gameObject;
        upgrade_menu = GameObject.FindAnyObjectByType<Upgrade_Menu_Script>().gameObject;
        pause = GameObject.FindAnyObjectByType<SceneLoaderManagerScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int p = 0;
        if (win_lose.GetComponent<Win_Lose_Script>().win_lose_panel.activeInHierarchy)
        {
            p++;
        }
        if (upgrade_menu.GetComponent<Upgrade_Menu_Script>().ui_elements.activeInHierarchy)
        {
            p++;
        }
        if (pause.GetComponent<SceneLoaderManagerScript>().pause_screen.activeInHierarchy)
        {
            p++;
        }

        if (p > 0)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible=false;
        }

    }
}
