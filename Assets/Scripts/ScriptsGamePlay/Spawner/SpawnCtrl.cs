using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : TunBehaviour
{
    [Header("SpawnCtrl")]

    [SerializeField] protected SpawnPoint spawnpoint;

    public SpawnPoint SpawnPoint => spawnpoint;

    [SerializeField] protected Spawner spawner;

    public Spawner Spawner => spawner;

    protected override void LoadComponent()
    {
        this.LoadSpawnPoint();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnpoint != null) return;
        this.spawnpoint = FindObjectOfType<SpawnPoint>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoint");
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner");
    }
}
