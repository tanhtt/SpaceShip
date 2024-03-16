using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHP : TextBase
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;
        this.text.SetText("HP: " + hp + "/" + hpMax);
    }
}