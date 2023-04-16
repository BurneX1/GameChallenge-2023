using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthProgres : MonoBehaviour
{
    public float max = 40;
    [Range(0, 100)]
    public float actualvalue;
    public GameObject[] alert;
    public Image bar;
    public bool hide;
    public float timeForDown;
    public float downTimer;

    public float loseTimer;
    private float loseTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DownTime()
    {
        if(downTimer >= timeForDown)
        {
            actualvalue -= Time.deltaTime;
        }
        else
        {
            downTimer += Time.deltaTime;
        }


    }

    public void LoseTime()
    {
        if(actualvalue <= 0)
        {
            if(loseTime>=loseTimer)
            {
                MenuInterfaceController.ChangeSceen("MenuPrincipal");
            }
            else
            {
                loseTime += Time.deltaTime;
            }
        }
        else
        {
            loseTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BarRefresh(bar, actualvalue, max);
        if(actualvalue<= 5)
        {
            /*if(hide==false)*/ ShowAlert();

        }
        else
        {

            /*if (hide == true)*/ HideAlert();
        }
        DownTime();
        LoseTime();
    }

    private void BarRefresh(Image box, float act, float max)
    {
        if (box.fillAmount != act / max)
        {
            box.fillAmount = Mathf.Lerp(box.fillAmount, act / max, Time.deltaTime );
        }
    }

    void HideAlert()
    {
        
        foreach(GameObject obj in alert)
        {
            obj.SetActive(false);
        }
        hide = true;
    }
    void ShowAlert()
    {

        foreach (GameObject obj in alert)
        {
            obj.SetActive(true);
        }
        hide = false;
    }
}
