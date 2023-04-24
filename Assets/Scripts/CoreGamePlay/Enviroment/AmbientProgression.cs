using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbientProgression : MonoBehaviour
{
    bool enumer = false;

    [Header("Enviroment")]
    public Image imgEnv;
    public float maxEnviroment = 1;
    [Range(0, 100)]
    [SerializeField]
    private float actEnv;
    public GameObject[] envParts;
    
    [Header("TreeGrowth")]
    public Image imgGrw;
    public float maxTreeGrowth = 1;
    [Range(0,100)]
    [SerializeField]
    private float actTrGrw;
    public GameObject[] treeParts;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if(imgEnv)
        {
            BarRefresh(imgEnv, actEnv, maxEnviroment);
        }

        if(imgGrw)
        {
            BarRefresh(imgGrw, actTrGrw, maxTreeGrowth);
        }
        //SetEnv();
        //IncraseBars();
        //SetGrowth();
    }

    void IncraseBars()
    {
        SetEnviromentValue(actEnv + (Time.deltaTime * 0.5f));
        SetTreeGrowth(actTrGrw + (Time.deltaTime * 0.5f));
    }
    public float GetEnviromentValue()
    {
        return actEnv;
    }

    public void SetEnviromentValue(float val)
    {
        if(val > maxEnviroment)
        {
            actEnv = maxEnviroment;
            MenuInterfaceController.ChangeSceen("PantallaVictoria");
        }
        else
        {
            actEnv = val;
        }

        SetEnv();
    }

    public float GetTreeGrowth()
    {
        return actTrGrw;
    }

    public void SetTreeGrowth(float val)
    {

        if (val > maxTreeGrowth)
        {
            actTrGrw = maxTreeGrowth;
        }
        else
        {
            actTrGrw = val;
        }

        SetGrowth();
    }

    void SetEnv()
    {
        if (envParts.Length == 0) return;
        float baseVal = 1.0f / (envParts.Length- 1) * maxEnviroment;
        float actVal = actEnv;
        //Debug.Log(" " + baseVal + " " + actVal + " " + (int)(maxEnviroment / baseVal) + " ");
        for(int i =0; i < (int)(maxEnviroment/baseVal);i++)
        {

            if (actVal >= maxEnviroment)
            {

                ActivePart(envParts.Length - 1, envParts);

            }
            else if(i * baseVal <= actVal && actVal < (i+1) * baseVal)
            {
                
                ActivePart(i, envParts);
            }
        }

    }

    void ActivePart(int val, GameObject[] targetList)
    {

        if (targetList[val])
        {
            targetList[val].SetActive(true);
            for (int i = 0; i < targetList.Length; i++)
            {

                if(i!=val)
                {

                    if(targetList[i].activeSelf == true) StartCoroutine(UIDegrade(targetList[i].GetComponent<Animator>()));


                }
         
            }
        }
        else
        {

            return;
        }

    }

    void SetGrowth()
    {
        if (treeParts.Length == 0) return;
        float baseVal = 1.0f / (treeParts.Length-1) * maxTreeGrowth;
        float actVal = actTrGrw;
        //Debug.Log(" " + baseVal + " " + actVal + " " + (int)(maxTreeGrowth / baseVal) + " ");
        for (int i = 0; i < (int)(maxTreeGrowth / baseVal); i++)
        {
            if (actVal >= maxTreeGrowth)
            {

                ActivePart(treeParts.Length - 1, treeParts);

            }
            else if (i * baseVal <= actVal && actVal < (i + 1) * baseVal)
            {
                ActivePart(i, treeParts);
            }
        }
    }
    // Update is called once per frame
    private void BarRefresh(Image box, float act, float max)
    {
        if (box.fillAmount != act / max)
        {
            box.fillAmount = Mathf.Lerp(box.fillAmount, act / max, Time.deltaTime);
        }
    }
    public  IEnumerator UIDegrade(Animator obj)
    {
        if(enumer == true)
        {
            yield return 0;
        }
   
        enumer = true;
        obj.Play("End");
        yield return new WaitForSeconds(1);
        obj.gameObject.SetActive(false);
        enumer = false;
    }
}
