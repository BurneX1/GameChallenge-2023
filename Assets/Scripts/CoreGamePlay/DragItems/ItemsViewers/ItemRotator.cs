using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    public GameObject[] spwnPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemRotation();
    }

    public void UpdateItemRotation()
    {
        for (int i = 0; i < spwnPoints.Length; i++)
        {
            spwnPoints[i].transform.rotation = Quaternion.identity;

        }

    }


}

