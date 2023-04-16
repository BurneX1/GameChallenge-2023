using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ClorofileReciver : MonoBehaviour
{
    public UnityEvent OnError;
    public UnityEvent OnCorrect;
    public AmbientProgression progress;

    public DropBox box;
    public Items actualItm;
    public Items[] ReceptionValues;
    public Image receptShower;
    public float timeForChange;
    private float timer;
    public bool enviroment;
    private void OnEnable()
    {
        box.Droped += CheckContent;
    }
    private void OnDisable()
    {
        box.Droped -= CheckContent;
    }
    void ChangeReception()
    {
        if (ReceptionValues.Length <= 1) return;

        int newIt = Random.Range(0, ReceptionValues.Length);
        if(ReceptionValues[newIt]== actualItm)
        {
            newIt = (newIt + 1) % (ReceptionValues.Length - 1);
        }

        
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
        Debug.Log(box.beforeItm.itm  + " / " + actualItm);
        if (box.beforeItm.name == actualItm.name)
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

    public void CorrectAnswer()
    {
        OnCorrect.Invoke();
        if (progress == null) return;

        if(enviroment)
        {
            progress.SetEnviromentValue(progress.GetEnviromentValue() + box.beforeItm.itm.score);
        }
        else
        {
            progress.SetTreeGrowth(progress.GetTreeGrowth() + box.beforeItm.itm.score);
        }
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
