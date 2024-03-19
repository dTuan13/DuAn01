using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [SerializeField] protected float hp = 70;
    public float Hp { get => hp; set => hp = value; }

    [SerializeField] protected float hpMax = 100;
    public float HpMax { get => hpMax; set => hpMax = value; }

    protected override void FixedUpdate()
    {
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpCurrent = (float)hp / hpMax;
        this.slider.value = hpCurrent;
    }

    protected override void OnChanged(float newValue)
    {

    }
}
