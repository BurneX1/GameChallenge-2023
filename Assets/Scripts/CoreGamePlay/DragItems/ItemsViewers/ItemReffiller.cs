using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReffiller : MonoBehaviour
{
    public string objTag = "ItmContainer";
    public GameObject[] ItemsList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == objTag)
        {
            DropBox drop = collision.gameObject.GetComponent<DropBox>();

            drop.Clear();
            //Debug.Log(gameObject + " enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objTag)
        {
            DropBox drop = collision.gameObject.GetComponent<DropBox>();
            GameObject newItem = Instantiate(ItemsList[Random.Range(0, ItemsList.Length)], collision.gameObject.transform);

            drop.ForceAdd(newItem);
            //Debug.Log(gameObject + " exit");
        }
    }
}
