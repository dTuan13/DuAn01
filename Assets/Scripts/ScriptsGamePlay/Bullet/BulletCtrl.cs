using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TunBehaviour
{
    [Header("BulletCtrl")]

    [SerializeField] protected Despawn despawn;

    public Despawn Despawn => despawn;

    [SerializeField] protected DamageSender damageSender;

    public DamageSender DamageSender => damageSender;

    [SerializeField] protected BulletFly bulletFly;

    public BulletFly BulletFly => bulletFly;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
        this.LoadDamageSender();
        this.LoadBulletFly();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": LoadDespawn");
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + ": LoadDamageSender");
    }

    protected virtual void LoadBulletFly()
    {
        if (this.bulletFly != null) return;
        this.bulletFly = GetComponentInChildren<BulletFly>();
        Debug.LogWarning(transform.name + ": LoadBulletFly");
    }
}
