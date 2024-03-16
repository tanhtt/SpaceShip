using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryAbstract : SaiMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryCtrl invCtrl;
    public UIInventoryCtrl InvCtrl => invCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.invCtrl != null) return;
        this.invCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }
}
