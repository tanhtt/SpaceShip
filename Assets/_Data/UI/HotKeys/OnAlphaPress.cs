using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAlphaPress : UIHotKeysAbstract
{
    private void Update()
    {
        this.CheckAlphaPress();
    }

    protected virtual void CheckAlphaPress()
    {
        if (InputHotKeysManager.Instance.isAlpha1) this.Press(0);
        if (InputHotKeysManager.Instance.isAlpha2) this.Press(1);
        if (InputHotKeysManager.Instance.isAlpha3) this.Press(2);
        if (InputHotKeysManager.Instance.isAlpha4) this.Press(3);
        if (InputHotKeysManager.Instance.isAlpha5) this.Press(4);
        if (InputHotKeysManager.Instance.isAlpha6) this.Press(5);
        if (InputHotKeysManager.Instance.isAlpha7) this.Press(6);
    }

    protected virtual void Press(int alpha)
    {
        Debug.Log("Press: " + (alpha + 1));
        ItemSlot itemSlot = this.uiHotKeysCtrl.itemSlots[alpha];
        Pressable pressable = itemSlot.GetComponentInChildren<Pressable>();
        if (pressable == null) return;
        pressable.Pressed();
    }
}
