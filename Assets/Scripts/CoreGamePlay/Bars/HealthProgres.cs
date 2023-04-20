using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class HealthProgres : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] loadParts;
    private int fragCount = -1;
    public bool fragmented;
    public float max = 40;
    [Range(0, 100)]
    public float actualvalue;
    public GameObject[] alert;
    public Image bar;
    public bool hide;

    public bool ignoreTime;
    public float timeForDown;
    public float downTimer;

    public float loseTimer;
    private float loseTime;

    // Start is called before the first frame update
    void Start()
    {

        FragmentedSetup();
    }
    void FragmentedSetup()
    {
        if (fragmented)
        {

            foreach (Transform trs in GetComponentsInChildren<Transform>())
            {
                if (trs != gameObject.transform)
                {
                    GameObject[] tmpConct = { trs.gameObject };

                    if (loadParts.Length == 0)
                    {
                        loadParts = tmpConct;

                    }
                    else
                    {
                        loadParts = loadParts.Concat(tmpConct).ToArray();
                    }
                }
                max = loadParts.Length;
            }

        }
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
        if (fragmented)
        {
            RefreshCount();
        }
        else
        {
            BarRefresh(bar, actualvalue, max);
        }
        if (actualvalue<= 15)
        {
            /*if(hide==false)*/ ShowAlert();

        }
        else
        {

            /*if (hide == true)*/ HideAlert();
        }
        if(ignoreTime==false)
        {
            DownTime();
            LoseTime();
        }

    }

    private void BarRefresh(Image box, float act, float max)
    {
        if (box.fillAmount != act / max)
        {
            box.fillAmount = Mathf.Lerp(box.fillAmount, act / max, Time.deltaTime );
        }
    }

    private void RefreshCount()
    {
        if((int)actualvalue != fragCount)
        {
            for(int i = 0; i < loadParts.Length; i++)
            {
                if(i < (int)actualvalue)
                {
                    loadParts[i].SetActive(true);
                }
                else
                {
                    loadParts[i].SetActive(false);
                }
            }
            fragCount = (int)actualvalue;
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
