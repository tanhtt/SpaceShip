using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPBar : SaiMonoBehaviour
{
    [Header("Player HP Bar")]
    [SerializeField] protected SliderHP sliderHP;

    protected virtual void FixedUpdate()
    {
        this.SetPlayerHP();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
    }

    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
    }

    protected virtual void SetPlayerHP()
    {
        float hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
        float hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;

        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetHPMax(hpMax);
    }
}
