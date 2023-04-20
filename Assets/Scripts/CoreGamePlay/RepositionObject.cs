using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionObject : MonoBehaviour
{
    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = anchor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
