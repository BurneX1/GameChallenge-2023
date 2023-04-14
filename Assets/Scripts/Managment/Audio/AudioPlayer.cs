using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "01_Menu": AudioManager.Instance.Play("Theme", AudioManager.Instance.sounds); break;
            case "03_Credits": AudioManager.Instance.Play("Theme", AudioManager.Instance.sounds); break;
        }
    }
}