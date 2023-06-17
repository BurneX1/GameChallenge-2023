using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerSplashScreen : MonoBehaviour
{
    public int HistoriaHecha;
    public string SName;
    public string HName;

    private void Start()
    {
        HistoriaHecha = PlayerPrefs.GetInt("HistoriaHecha");
    }
    public void ChangeSceneSplash()
    {
        //SceneChange.Change(SName);
        ComprobarHistoria();
    }

    private void ComprobarHistoria()
    {
        
        if (HistoriaHecha == 1)
        {
            SceneChange.Change(SName); //Funciona sin el FadeOut
        }
        else
        {
            SceneChange.Change(HName);
            PlayerPrefs.SetInt("HistoriaHecha", 1);
        }
           
    }
}
