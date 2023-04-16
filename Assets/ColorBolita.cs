using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorBolita : MonoBehaviour
{
    public Image icon;
    public Color32[] colors;
    public ClorofileReciver reciver;


    // Update is called once per frame
    void Update()
    {
        if(icon.color!= colors[reciver.actualNum])
        {
            icon.color = colors[reciver.actualNum];
        }


    }
}
