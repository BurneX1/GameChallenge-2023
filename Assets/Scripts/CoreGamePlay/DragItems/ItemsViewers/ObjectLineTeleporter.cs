using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLineTeleporter : MonoBehaviour
{
    public GameObject[] objcets;
    public Vector2 vel;
    public Transform respawnPos;
    // Start is called before the first frame update
    void Start()
    {
        SetRigidbody();
    }

    void SetRigidbody()
    {
        foreach (GameObject tr in objcets)
        {
            Rigidbody2D rb;
            if (tr.GetComponent<Rigidbody2D>() == null)
            {
                rb = tr.AddComponent<Rigidbody2D>();
            }
            else
            {
                rb = tr.GetComponent<Rigidbody2D>();
            }
            rb.isKinematic = true;
            rb.velocity =vel;
        
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ItmContainer")
        {
            collision.gameObject.transform.position = respawnPos.position;
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
