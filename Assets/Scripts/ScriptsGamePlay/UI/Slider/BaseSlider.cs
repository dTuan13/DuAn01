using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : TunBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }

    protected override void Start()
    {
        base.Start();
        this.AddOnChangedEvent();
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        if (this.slider == null)
        {
            Debug.Log(transform.name + ": LoadSlider");
            return;
        }
    }

    protected virtual void AddOnChangedEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected abstract void OnChanged(float newValue);
}
