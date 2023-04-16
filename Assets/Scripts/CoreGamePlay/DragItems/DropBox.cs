using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class DropBox : MonoBehaviour, IDropHandler
{
    public event Action Refresh = delegate { };
    Items item;
    DragableItem beforeItm;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DragableItem dragItem = dropped.GetComponent<DragableItem>();
            dragItem.afterParent = transform;
            item = dragItem.itm;
            beforeItm = dragItem;
            Refresh();
        }
    }

    public Items GetItem()
    {
        if(transform.childCount == 0) return null;
        
        return item;

    }

    public void ForceRefresh()
    {
        Refresh.Invoke();
    }
    private void OnDisable()
    {
        Clear();
    }
    public void Clear()
    {


        foreach (Transform trs in transform)
        {
            trs.gameObject.GetComponent<DragableItem>().afterParent = null;
            Destroy(trs.gameObject);
        }

        if (beforeItm)
        {
            beforeItm.afterParent = null;
        }
    }

    public void ForceAdd(GameObject obj)
    {


        DragableItem dragItem = obj.GetComponent<DragableItem>();
        dragItem.afterParent = transform;
        item = dragItem.itm;
        beforeItm = dragItem;
        Refresh();
    }
}
