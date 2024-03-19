using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapsAbstract : TunBehaviour
{
    [Header("TrapsAbstract")]

    [SerializeField] protected TrapsCtrl trapsCtrl;

    public TrapsCtrl TrapsCtrl { get => trapsCtrl; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTrapsCtrl();
    }

    protected virtual void LoadTrapsCtrl()
    {
        if (this.trapsCtrl != null) return;
        this.trapsCtrl = transform.parent.GetComponent<TrapsCtrl>();
        if (this.trapsCtrl == null) Debug.LogWarning(transform.name + ": LoadTrapsCtrl");
    }
}
