using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCtrl : TrapsCtrl
{
    [Header("BombCtrl")]
    [SerializeField] protected Transform fx;

    public Transform FX => fx;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFX();
    }

    protected virtual void LoadFX()
    {
        if (this.fx != null) return;
        this.fx = transform.Find("FX");
        Debug.LogWarning(transform.name + ": LoadFX");
    }
}
