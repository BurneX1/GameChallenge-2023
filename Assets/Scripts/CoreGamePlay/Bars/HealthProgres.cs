using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
public class HealthProgres : MonoBehaviour
{
    private Color green = new Color(0.40000f, 0.95294f, 0.30980f, 1);    
    private Color yelow = new Color(0.95294f, 0.92549f, 0.30980f, 1);    
    private Color red = new Color(1.00000f, 0.00392f, 0.24314f, 1);
    private bool finished = false;
    public UnityEvent finishBarEv;
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
        if(finished==false && actualvalue >= max)
        {
            finishBarEv.Invoke();
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
            Color setColor;
            if(actualvalue<max/3)
            {
                setColor = red;
            }
            else if (actualvalue < (max / 2)+1)
            {
                setColor = yelow;
            }
            else
            {
                setColor = green;
            }

            for(int i = 0; i < loadParts.Length; i++)
            {
                if(i < (int)actualvalue)
                {
                    loadParts[i].GetComponent<Image>().color = setColor;
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

    public void Increase(int value)
    {
        actualvalue += value;
    }
    void HideAlert()
    {
        if (alert.Length <= 0) return;
        foreach (GameObject obj in alert)
        {
            obj.SetActive(false);
        }
        hide = true;
    }
    void ShowAlert()
    {
        if (alert.Length <= 0) return;
        foreach (GameObject obj in alert)
        {
            obj.SetActive(true);
        }
        hide = false;
    }
}
