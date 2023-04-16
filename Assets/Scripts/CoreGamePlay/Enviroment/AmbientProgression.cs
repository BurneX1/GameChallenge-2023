using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientProgression : MonoBehaviour
{
    bool enumer = false;

    [Header("Enviroment")]
    public float maxEnviroment = 1;
    [Range(0, 100)]
    [SerializeField]
    private float actEnv;
    public GameObject[] envParts;
    
    [Header("TreeGrowth")]
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
        SetEnv();

        SetGrowth();
    }

    public float GetEnviromentValue()
    {
        return actEnv;
    }

    public void SetEnviromentValue(float val)
    {
        actEnv = val;
        SetEnv();
    }

    public float GetTreeGrowth()
    {
        return actTrGrw;
    }

    public void SetTreeGrowth(float val)
    {
        actTrGrw = val;
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
