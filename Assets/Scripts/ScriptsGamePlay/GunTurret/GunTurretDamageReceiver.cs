using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class GunTurretDamageReceiver : DamageReceiver
{
    [Header("GunTurret DamageReceiver")]
    [SerializeField] protected int damageMax = 20;

    [SerializeField] protected CapsuleCollider2D capsuleCollider2D;

    [SerializeField] protected TurretCtrl turretCtrl;

    public TurretCtrl TurretCtrl { get => turretCtrl; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTurretCtrl();
        this.LoadCollider();
    }
    protected virtual void LoadTurretCtrl()
    {
        if (this.turretCtrl != null) return;
        this.turretCtrl = transform.parent.GetComponent<TurretCtrl>();
        Debug.LogWarning(transform.name + ": LoadTurretCtrl");
    }

    protected virtual void LoadCollider()
    {
        if (this.capsuleCollider2D != null) return;
        this.capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCollider");
        this.capsuleCollider2D.isTrigger = true;
        Vector3 size = new Vector3(0.7f, 1.4f, 0);
        this.capsuleCollider2D.size = size;
    }
    protected override void OnDead()
    {
        this.turretCtrl.Despawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.hpMax = this.damageMax;
    }
}
