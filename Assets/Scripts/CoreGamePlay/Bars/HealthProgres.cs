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

    // Start is called before the first frame update
    void Start()
    {
        
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
