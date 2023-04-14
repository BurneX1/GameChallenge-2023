using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Data
{
    public int score = 0;
    public bool firstTime = false;

    public int language = 1;


    public float sndVol = 0.5f;
    public bool sndMute = false;
    public float mscVol = 0.5f;
    public bool mscMute = false;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if(instance == null) instance = this;
        SaveSystem.Load();
    }

    private void Start()
    {
        SaveSystem.Save();
    }
    private void OnApplicationQuit() => SaveSystem.Save();
}