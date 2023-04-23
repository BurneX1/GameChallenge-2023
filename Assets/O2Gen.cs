using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Gen : MonoBehaviour
{
    public GameObject oxigen;
    public float UpForce;
    public float xRange;
    public float oxigenTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        GameObject obj = Instantiate(oxigen,transform);
        obj.GetComponent<FedbckAnim>().touchOver();
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2( Random.Range(xRange, xRange * -1), UpForce);
    }

    IEnumerator DelayDestroy(FedbckAnim ob)
    {
        yield return new WaitForSeconds(oxigenTime);
        ob.touchExit();
        yield return new WaitForSeconds(0.5f);
        ob.gameObject.SetActive(false);
    }
}
