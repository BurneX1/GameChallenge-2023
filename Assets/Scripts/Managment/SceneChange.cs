using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    public static Animator transition;
    public static SceneChange instance;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        transition = anim;

    }
    public static void Change(string sceneName)
    {
        instance.StartCoroutine(TransitionLoadScene(sceneName));
    }

    static IEnumerator TransitionLoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
