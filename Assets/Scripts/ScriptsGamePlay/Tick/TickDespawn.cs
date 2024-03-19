using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickDespawn : DespawnByTime
{
    [Header("TickDespawn")]
    [SerializeField] protected float timeTickDespawn = 0.5f;

    public override void DespawnObject()
    {
        TickSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLimit = this.timeTickDespawn;
    }
}
