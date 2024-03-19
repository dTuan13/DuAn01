using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : WeponAbstract
{
    [Header("Muzzle")]
    [SerializeField] protected Transform model;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel");
    }

    protected virtual void Update()
    {
        this.ShowMuzzle();
    }
    public virtual void ShowMuzzle()
    {
        if (Time.timeScale == 0) return; 
        this.model.gameObject.SetActive(this.weponCtrl.ObjectShooting.GetIsShooting);
    }
}
