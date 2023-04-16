using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorBolita : MonoBehaviour
{
    public Image icon;
    public Color32[] colors;
    public GameObject reciver;


    // Update is called once per frame
    void Update()
    {
        if(icon.color!= colors[reciver.GetComponent<ClorofileReciver>().actualNum])
        {
            icon.color = colors[reciver.GetComponent<ClorofileReciver>().actualNum];
        }
        transform.position = reciver.transform.position;

    }
}
