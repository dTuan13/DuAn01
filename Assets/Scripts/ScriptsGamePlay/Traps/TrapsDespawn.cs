using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDespawn : DespawnByTime
{
    [Header("TrapsDespawn")]
    [SerializeField] protected float timeDespawn = 4f;
    public override void DespawnObject()
    {
        TrapsSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLimit = this.timeDespawn;
    }
}
