using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeysAbstract : SaiMonoBehaviour
{
    [SerializeField] protected UIHotKeysCtrl uiHotKeysCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeysCtrl();
    }

    protected virtual void LoadUIHotKeysCtrl()
    {
        if (this.uiHotKeysCtrl != null) return;
        this.uiHotKeysCtrl = transform.parent.GetComponent<UIHotKeysCtrl>();
        Debug.Log(transform.name + ": LoadUIHotKeysCtrl", gameObject);
    }
}
