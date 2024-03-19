using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : TunBehaviour
{
    [Header("MonsterCtrl")]

    [SerializeField] protected Despawn despawn;

    public Despawn Despawn => despawn;

    [SerializeField] protected MonsterDamageSender damageSender;

    public MonsterDamageSender DamageSender => damageSender;

    [SerializeField] protected MonsterDamagerReceiver damageReceiver;

    public MonsterDamagerReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected ObjectMovement objectMovement;

    public ObjectMovement ObjectMovement => objectMovement;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
        this.LoadDamageSender();
        this.LoadDamageReceiver();
        this.LoadObjectMovement();
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
        this.damageSender = GetComponentInChildren<MonsterDamageSender>();
        Debug.LogWarning(transform.name + ": LoadDamageSender");
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<MonsterDamagerReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver");
    }

    protected virtual void LoadObjectMovement()
    {
        if (this.objectMovement != null) return;
        this.objectMovement = GetComponentInChildren<ObjectMovement>();
        Debug.LogWarning(transform.name + ": LoadObjectMovement");
    }
}
