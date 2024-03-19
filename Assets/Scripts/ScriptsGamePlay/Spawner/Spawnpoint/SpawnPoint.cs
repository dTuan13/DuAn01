using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : TunBehaviour
{
    [Header("Spawn Point")]
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.prefabs.Add(point);
        }
    }

    public virtual Transform RandomPoint()
    {
        int index = Random.Range(0, this.prefabs.Count);
        return this.prefabs[index];
    }
}
