using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : SaiMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0) return;
        Debug.Log("On Drop");
        GameObject objDrop = eventData.pointerDrag;
        DragItem dragItem = objDrop.GetComponent<DragItem>();
        dragItem.SetRealParent(transform);
    }
}
