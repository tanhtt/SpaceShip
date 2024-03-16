using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeysCtrl : SaiMonoBehaviour
{
    private static UIHotKeysCtrl instance;
    public static UIHotKeysCtrl Instance => instance;

    public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        base.Awake();
        if (UIHotKeysCtrl.instance != null) Debug.LogError("Only 1 UIHotKeysCtrl allow to exist");
        UIHotKeysCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemsSlot();
    }

    protected virtual void LoadItemsSlot()
    {
        if (this.itemSlots.Count > 0) return;
        ItemSlot[] arrayItems = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arrayItems);
        Debug.Log(transform.name + ": LoadItemsSlot", gameObject);
    }
}
