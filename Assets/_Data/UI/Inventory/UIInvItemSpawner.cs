using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;

    public static string normalItem = "UIInvItem";

    [Header("Inv Item Spawner")]
    //[SerializeField] protected Transform content;
    [SerializeField] protected UIInventoryCtrl uiInventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null) Debug.LogError("Only 1 UIInvItemSpawner allow to exist");
        UIInvItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIInvCtrl();
        if (this.holder != null) return;
        this.holder = this.uiInventoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadUIInvCtrl()
    {
        if (this.uiInventoryCtrl != null) return;
        this.uiInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInvCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        UIItemInventory uiItemInv = uiItem.GetComponent<UIItemInventory>();
        uiItemInv.SetItem(item);
        uiItem.gameObject.SetActive(true);
    }
}
