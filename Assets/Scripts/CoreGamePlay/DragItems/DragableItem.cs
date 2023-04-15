using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image img;
    [HideInInspector] public Transform afterParent;
    public Items itm;
    public void OnBeginDrag(PointerEventData eventData)
    {
        afterParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        img.raycastTarget = false;

        if (afterParent.GetComponent<DropBox>())
        {
            afterParent.GetComponent<DropBox>().ForceRefresh();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(afterParent);
        img.raycastTarget = true;
    }

}
