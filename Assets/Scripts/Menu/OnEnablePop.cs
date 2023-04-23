using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnablePop : MonoBehaviour
{
    public OpenPopUp popMang;
    public GameObject popPanel;
    public float delay;
    private void OnEnable()
    {
        StartCoroutine(DelayOpen(popPanel));
    } 

    IEnumerator DelayOpen( GameObject panel)
    {
        yield return new WaitForSeconds(delay);
        popMang.OpenPopTime(panel);
    }
}
