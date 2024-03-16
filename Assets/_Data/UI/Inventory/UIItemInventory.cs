using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : SaiMonoBehaviour
{
    [Header("UI Item Inventory")]

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumber => itemNumber;

    [SerializeField] protected Image itemSprite;
    public Image ItemSprite => itemSprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
        this.LoadItemSprite();
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.LogWarning(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemNumber").GetComponent<Text>();
        Debug.LogWarning(transform.name + ": LoadItemNumber", gameObject);
    }

    protected virtual void LoadItemSprite()
    {
        if (this.itemSprite != null) return;
        this.itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadItemSprite", gameObject);
    }

    public virtual void SetItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = this.itemInventory.itemProfile.itemName;
        this.itemNumber.text = this.itemInventory.itemCount.ToString();
        this.ItemSprite.sprite = this.itemInventory.itemProfile.itemSprite;
    }
}
