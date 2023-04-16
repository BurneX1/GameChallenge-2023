using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ClorofileReciver : MonoBehaviour
{
    public UnityEvent OnError;
    public UnityEvent OnCorrect;

    public DropBox box;
    public Items actualItm;
    public Items[] ReceptionValues;
    public Image receptShower;

    void ChangeReception()
    {
        actualItm = ReceptionValues[Random.Range(0, ReceptionValues.Length)];

        //if(receptShower)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
