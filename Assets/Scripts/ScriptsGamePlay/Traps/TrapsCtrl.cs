using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsCtrl : TunBehaviour
{
    [Header("TrapsCtrl")]

    [SerializeField] protected DespawnByTime despawn;

    public DespawnByTime Despawn => despawn;

    [SerializeField] protected DamageSender damageSender;

    public DamageSender DamageSender => damageSender;

    [SerializeField] protected TrapsImpact trapsImpact;

    public TrapsImpact TrapsImpact => trapsImpact;

    [SerializeField] protected Transform model;

    public Transform Model => model;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
        this.LoadDamageSender();
        this.LoadBombImpact();
        this.LoadModel();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<DespawnByTime>();
        Debug.LogWarning(transform.name + ": LoadDespawn");
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + ": LoadDamageSender");
    }

    protected virtual void LoadBombImpact()
    {
        if (this.trapsImpact != null) return;
        this.trapsImpact = GetComponentInChildren<TrapsImpact>();
        Debug.LogWarning(transform.name + ": LoadBombImpact");
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel");
    }

}
