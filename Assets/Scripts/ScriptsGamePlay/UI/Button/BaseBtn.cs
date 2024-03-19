using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : TunBehaviour
{
    [Header("BaseBtn")]

    [SerializeField] protected Button button;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadButton");
    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();


}
