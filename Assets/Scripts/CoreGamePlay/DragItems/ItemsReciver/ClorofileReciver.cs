using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ClorofileReciver : MonoBehaviour
{
    public UnityEvent OnError;
    public UnityEvent OnCorrect;
    public HealthProgres progress;

    public DropBox box;
    public Items actualItm;
    public int actualNum;
    public bool reciveAllList;
    public Items[] ReceptionValues;
    public Image receptShower;
    public float timeForChange;
    private float timer;

    private void OnEnable()
    {
        box.Droped += CheckContent;
    }
    private void OnDisable()
    {
        box.Droped -= CheckContent;
    }
    public void ChangeReception()
    {
        timer = 0;
        if (ReceptionValues.Length <= 1) return;

        int newIt = Random.Range(0, ReceptionValues.Length);
        if(ReceptionValues[newIt]== actualItm)
        {
            newIt = (newIt + 1) % (ReceptionValues.Length - 1);
        }

        actualNum = newIt;
        actualItm = ReceptionValues[newIt];
        
        if (receptShower) receptShower.sprite = actualItm.image;
    }

    void TimeLoad()
    {
        if(timer<=timeForChange)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ChangeReception();
            timer = 0;
        }
    }

    public void CheckContent()
    {
        if(reciveAllList)
        {
            for(int i = 0; i < ReceptionValues.Length; i++)
            {
                if (box.beforeItm.itm.itemName == ReceptionValues[i].itemName)
                {
                    CorrectAnswer();
                    Debug.Log("Nice");
                }
            }
        }
        else
        {
            Debug.Log(box.beforeItm.itm.name + " / " + actualItm.name);
            if (box.beforeItm.itm.itemName == actualItm.itemName)
            {
                CorrectAnswer();
                Debug.Log("Nice");
            }
            else
            {
                IncorrectAnswer();
                Debug.Log("Error");
            }
        }
        
        box.Clear();
    }

    public void CorrectAnswer()
    {
        OnCorrect.Invoke();
        if (progress == null) return;

        progress.actualvalue += +box.beforeItm.itm.score;
        progress.downTimer = 0;
    }

    public void IncorrectAnswer()
    {
        OnError.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeReception();
    }



    // Update is called once per frame
    void Update()
    {
        TimeLoad();
    }
}
