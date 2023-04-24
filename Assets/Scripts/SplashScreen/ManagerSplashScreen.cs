using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerSplashScreen : MonoBehaviour
{
    public string SName;

    public void ChangeSceneSplash()
    {
        SceneChange.Change(SName);
    }
}
