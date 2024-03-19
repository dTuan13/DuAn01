using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : TunBehaviour
{
    [Header("TurretCtrl")]

    [SerializeField] protected Despawn despawn;

    public Despawn Despawn => despawn;

    [SerializeField] protected DamageReceiver damageReceiver;

    public DamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": LoadDespawn");
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver");
    }

}
