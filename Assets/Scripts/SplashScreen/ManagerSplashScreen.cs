using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerSplashScreen : MonoBehaviour
{
    public string NameScene;
    public int Comprobador;

    public void Awake()
    {
        Comprobador = PlayerPrefs.GetInt("HistoriaTrue");
    }

    public void Start()
    {

        if(Comprobador == 1)
        {
            StartCoroutine(SplashChange());
        }
        else if(Comprobador == 0)
        {
            StartCoroutine(SplashChangeHistoria());
        }
    }

    IEnumerator SplashChange()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(NameScene);
    }
    IEnumerator SplashChangeHistoria()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Historia");
    }
}
