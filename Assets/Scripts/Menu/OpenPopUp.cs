using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopUp : MonoBehaviour
{
    public GameObject PopUpPrefab;

    public void OpenPop() => PopUpPrefab.SetActive(true);

    public void ClosePop() => PopUpPrefab.SetActive(false);
}
