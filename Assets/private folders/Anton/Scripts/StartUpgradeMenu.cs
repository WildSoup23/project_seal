using UnityEngine;

public class StartUpgradeMenu : MonoBehaviour
{
    public static StartUpgradeMenu instance;
    public bool willStart;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        willStart = false;
    }
}
