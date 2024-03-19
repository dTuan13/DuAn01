using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurretDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        GunTurretSpawner.Instance.Despawn(transform.parent);
    }
}
