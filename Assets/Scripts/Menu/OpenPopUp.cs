using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopUp : MonoBehaviour
{
    //public GameObject PopUpPrefab;


    #region NormalPops
    public void OpenPop(GameObject PopUp) => PopUp.SetActive(true);

    public void ClosePop(GameObject PopUp) => PopUp.SetActive(false);
    #endregion


    #region PopWithTimePause
    public void OpenPopTime(GameObject PopUp)
    {
        PopUp.SetActive(true);
        Time.timeScale= 0;
    }

    public void ClosePopTime(GameObject PopUp)
    {
        PopUp.SetActive(false);
        Time.timeScale = 1;
    }
    #endregion
}
