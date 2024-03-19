using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHpPlayer : TunBehaviour
{
    private static UpdateHpPlayer _instance;

    public static UpdateHpPlayer Instance => _instance;

    [SerializeField] protected Slider slider;

    protected override void Awake()
    {
        base.Awake();
        if (global::UpdateHpPlayer._instance != null)
        {
            Debug.LogWarning("Only UpdateHpPlayer allow to exists");
            return;
        }
        global::UpdateHpPlayer._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider");
    }

    public virtual void UpdateValueSliderHpPlayer(int hp, int hpMax)
    {
        if (hpMax <= 0f) return;
        this.slider.value = (float)Math.Round((float)hp / hpMax, 2);
    }
}
