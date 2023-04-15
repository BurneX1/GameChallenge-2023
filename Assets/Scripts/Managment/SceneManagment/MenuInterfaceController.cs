using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MenuInterfaceController : MonoBehaviour
{
    [Header("FadeScreen")]
    public float duration;

    [Header("Screens")]
    public int currentScreenIndex = 1;
    public RectTransform[] screens;

    private void Start()
    {

        if (!SaveSystem.data.firstTime)
        {
            //ChangeScreen(5);
            SaveSystem.data.firstTime = true;
            SaveSystem.Save();
        }
    }
    
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
           if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (currentScreenIndex != 0) ChangeScreen(0);

            }
        }
    }

    public void ChangeScreen(int targetScreen) => MoveScreens(targetScreen);

    public void ChangeSceen(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void MoveScreens(int targetScreen)
    {
        
        if (targetScreen == currentScreenIndex) return;
        int currentScreen = currentScreenIndex;

        currentScreenIndex = targetScreen;
        screens[targetScreen].gameObject.SetActive(true);
        Vector2 dir = new Vector2(0, 0);

        if (screens[targetScreen].position.x - screens[currentScreen].position.x > 0) dir.x = 1;
        else if(screens[targetScreen].position.x - screens[currentScreen].position.x < 0) dir.x = -1;

        if (screens[targetScreen].position.y - screens[currentScreen].position.y > 0) dir.y = 1;
        else if (screens[targetScreen].position.y - screens[currentScreen].position.y < 0) dir.y = -1;

        int xMoveDistance = (int)Mathf.Abs(screens[targetScreen].position.x - screens[currentScreen].position.x);
        int yMoveDistance = (int)Mathf.Abs(screens[targetScreen].position.y - screens[currentScreen].position.y);

        for (int i = 0; i < screens.Length; i++)
        {
            if(dir.x == 1)
            {
                screens[i].DOAnchorPosX(screens[i].position.x + xMoveDistance, duration, true);
                screens[i].DOMoveX(screens[i].position.x - xMoveDistance, duration, true);
                if (currentScreen != 0) StartCoroutine(DesactiveOnTime(screens[currentScreen].gameObject, duration));
            }
            else if(dir.x == -1)
            {
                screens[i].DOAnchorPosX(screens[i].position.x - xMoveDistance, duration, true);
                screens[i].DOMoveX(screens[i].position.x + xMoveDistance, duration, true);
                if (currentScreen != 0) StartCoroutine(DesactiveOnTime(screens[currentScreen].gameObject, duration));
            }

            if (dir.y == 1)
            {
                screens[i].DOAnchorPosY(screens[i].position.y + yMoveDistance, duration, true);
                screens[i].DOMoveY(screens[i].position.y - yMoveDistance, duration, true);
                if (currentScreen != 0) StartCoroutine(DesactiveOnTime(screens[currentScreen].gameObject, duration));
            }
            else if (dir.y == -1)
            {
                screens[i].DOAnchorPosY(screens[i].position.y - yMoveDistance, duration, true);
                screens[i].DOMoveY(screens[i].position.y + yMoveDistance, duration, true);
                if (currentScreen != 0) StartCoroutine(DesactiveOnTime(screens[currentScreen].gameObject, duration));
            }

        }
    }



    public void TweenPopUp(Transform popUp)
    {

        popUp.localScale = Vector3.zero;
        popUp.gameObject.SetActive(true);
        popUp.DOScale(1, duration);
    }

    public void HidePopUp(Transform popUp) => StartCoroutine(hidePop(popUp));

    private IEnumerator hidePop(Transform popUp)
    {
        popUp.DOScale(0, duration);
        yield return new WaitUntil(() => popUp.localScale == Vector3.zero);

        popUp.gameObject.SetActive(false);
    }


    public void RedirectToLink(string link) => Application.OpenURL(link);

    IEnumerator DesactiveOnTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

}
