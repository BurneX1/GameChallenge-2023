using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTutorial : MonoBehaviour
{
    public static ManagerTutorial Instance;

    public int historiaHecha = 0;

    public void Awake()
    {
        Instance = this;
        historiaHecha = PlayerPrefs.GetInt("HistoriaTrue");
    }
    public void Start()
    {
        historiaHecha = 1;
        PlayerPrefs.SetInt("HistoriaTrue", 1);
    }
}
