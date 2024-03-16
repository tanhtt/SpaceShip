using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float hpMax = 100;
    [SerializeField] protected float hp = 70;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = this.hp / this.hpMax;
        this.slider.value = hpPercent;
    }

    protected override void OnChanged(float newValue)
    {
        //Debug.Log("Changed");
    }

    public virtual void SetHPMax(float hpMax)
    {
        this.hpMax = hpMax;
    }

    public virtual void SetCurrentHP(float currentHP)
    {
        this.hp = currentHP;
    }
}
