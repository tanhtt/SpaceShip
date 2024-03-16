using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : SaiMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Transform realParent;
    [SerializeField] protected Image image;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }

    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On Begin Drag");
        this.realParent = transform.parent;
        transform.SetParent(UIHotKeysCtrl.Instance.transform);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag");
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On End Drag");
        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
    }
}
