using System;
using UnityEngine;

public class TheKeeper : MonoBehaviour
{
    public float money;
    public float speed;
    public float accel;
    public float dive;
    public float def;
    public string level;
    public bool hasPlayed;
    public bool hasDied;

    private TheKeeper instance;

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
}
