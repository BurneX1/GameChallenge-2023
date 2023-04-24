using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class ManagerHistoria : MonoBehaviour
{
    public int HistoriaHecha;
    public string SName;
    private void Awake()
    {
        StartCoroutine(ComprobarHistoria());
    }
    public void CompletarHistoria()
    {
        HistoriaHecha = 1;
        PlayerPrefs.SetInt("HistoriaHecha", HistoriaHecha);
        SceneChange.Change(SName); //Funciona con el FadeOut
    }
    IEnumerator ComprobarHistoria()
    {
        HistoriaHecha = PlayerPrefs.GetInt("HistoriaHecha");
        if(HistoriaHecha == 1)
            SceneManager.LoadScene(SName); //Funciona sin el FadeOut

        yield return null;
    }
}
