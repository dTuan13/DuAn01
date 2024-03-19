using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointFollowTarget : TunBehaviour
{
    [Header("Spawnpoin Follow Target")]

    [SerializeField] protected Vector3 target;

    [SerializeField] protected float distanceSpawn = 4f;

    public virtual Vector3 SpawnPoint()
    {
        Vector3 pos = this.target + new Vector3 (Random.Range(-1f, 1f) * this.distanceSpawn, Random.Range(-1f, 1f) * this.distanceSpawn, 0);
        return pos;
    }
}
