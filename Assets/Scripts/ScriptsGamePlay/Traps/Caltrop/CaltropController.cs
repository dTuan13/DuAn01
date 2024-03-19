using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaltropController : TunBehaviour
{
    [Header("CaltropController")]

    [SerializeField] protected TrapsCtrl trapsCtrl;

    public TrapsCtrl TrapsCtrl { get => trapsCtrl; }

    [SerializeField] protected int caltropDamage = 2;

    [SerializeField] protected float timeDespawn = 3.5f;

    [SerializeField] protected float radiusCollider = 0.2f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTrapsCtrl();
    }

    protected virtual void LoadTrapsCtrl()
    {
        if (this.trapsCtrl != null) return;
        this.trapsCtrl = transform.GetComponent<TrapsCtrl>();
        if (this.trapsCtrl == null) Debug.LogWarning(transform.name + ": LoadTrapsCtrl");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.trapsCtrl.DamageSender.Damage = this.caltropDamage;
        this.trapsCtrl.Despawn.TimeLimit = this.timeDespawn;
        this.trapsCtrl.TrapsImpact.CircleCollider2D.radius = this.radiusCollider;
    }
}
