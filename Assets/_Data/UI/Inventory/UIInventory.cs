using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    public InventorySort inventorySort;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        //this.Close();
        InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        isOpen = !isOpen;
        if (isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        transform.parent.gameObject.SetActive(true);
        isOpen = true;
    }

    public virtual void Close()
    {
        transform.parent.gameObject.SetActive(false);
        isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!isOpen) return;
        this.invCtrl.UIInvItemSpanwer.ClearItems();
        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.invCtrl.UIInvItemSpanwer;
        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
        this.SortItems();
    }

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        //Debug.Log("== InventorySort.ByName ==");
        int itemCount = this.invCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.invCtrl.Content.GetChild(i);
            nextItem = this.invCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;
            switch (this.inventorySort)
            {
                case InventorySort.SortByName:
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;

                    isSwap = string.Compare(currentName, nextName) == 1;
                    //Debug.Log(i + ": " + currentName + " | " + nextName + " = " + isSwap);
                    break;
                case InventorySort.SortByCount:
                    int currentCount = currentUIItem.ItemInventory.itemCount;
                    int nextCount = nextUIItem.ItemInventory.itemCount;

                    isSwap = currentCount < nextCount;
                    //Debug.Log(i + ": " + currentCount + " | " + currentCount + " = " + isSwap);
                    break;
            }

            if (isSwap)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting) this.SortItems();
        
    }

    //protected virtual void SortByName()
    //{
    //    Debug.Log("== InventorySort.ByName ==");
    //    int itemCount = this.invCtrl.Content.childCount;
    //    Transform currentItem, nextItem;
    //    UIItemInventory currentUIItem, nextUIItem;
    //    ItemProfileSO currentProfile, nextProfile;
    //    string currentName, nextName;

    //    bool isSorting = false;
    //    for (int i = 0; i < itemCount - 1; i++)
    //    {
    //        currentItem = this.invCtrl.Content.GetChild(i);
    //        nextItem = this.invCtrl.Content.GetChild(i + 1);

    //        currentUIItem = currentItem.GetComponent<UIItemInventory>();
    //        nextUIItem = nextItem.GetComponent<UIItemInventory>();

    //        currentProfile = currentUIItem.ItemInventory.itemProfile;
    //        nextProfile = nextUIItem.ItemInventory.itemProfile;

    //        currentName = currentProfile.itemName;
    //        nextName = nextProfile.itemName;

    //        int compare = string.Compare(currentName, nextName);

    //        if (compare == 1)
    //        {
    //            this.SwapItems(currentItem, nextItem);
    //            isSorting = true;
    //        }

    //        Debug.Log(i + ": " + currentName + " | " + nextName + " = " + compare);
    //    }

    //    if (isSorting) this.SortByName();
    //}

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
