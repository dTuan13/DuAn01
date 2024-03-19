using System.Collections;
using UnityEngine;

public class SpawnRandom : TunBehaviour
{
    [Header("Spawn Random")]

    [SerializeField] protected SpawnCtrl spawnCtrl;

    public SpawnCtrl SpawnCtrl => spawnCtrl;

    [SerializeField] protected int randomLimit = 4;

    [SerializeField] protected float timeDelayRandom = 2f;

    [SerializeField] protected float timeDelayTick = 0.5f;

    [SerializeField] protected bool isRandom;

    [SerializeField] protected int countObjOneRandom = 1;

    protected override void Start()
    {
        this.isRandom = true;
        InvokeRepeating(nameof(this.SpawnRandoming), 0, this.timeDelayRandom + this.timeDelayTick);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnCtrl();
    }

    protected virtual void LoadSpawnCtrl()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = GetComponent<SpawnCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnCtrl");
    }

    protected virtual Transform SpawnTick(string nameTick, Vector3 pos)
    {
        Transform tick = TickSpawner.Instance.Spawn(nameTick, pos, Quaternion.identity);
        tick.transform.gameObject.SetActive(true);
        return tick;
    }

    protected virtual void SpawnRandoming()
    {
        this.isRandom = (this.SpawnCtrl.Spawner.RandomCount < this.randomLimit);
        if (!this.isRandom) return;
        StartCoroutine(this.Randoming());
    }

    IEnumerator Randoming()
    {
        yield return new WaitForSeconds(this.timeDelayRandom);

        Vector3 pos;
        Transform tick, prefab, newPrefab;

        for(int i=0; i < this.countObjOneRandom; i++)
        {
            pos = this.spawnCtrl.SpawnPoint.RandomPoint().position;

            tick = this.SpawnTick(this.SpawnCtrl.Spawner.TickAppear, pos);

            if (tick == null) yield return null;

            yield return new WaitForSeconds(this.timeDelayTick);

            prefab = this.spawnCtrl.Spawner.RandomPrefab();

            newPrefab = this.spawnCtrl.Spawner.Spawn(prefab, pos, transform.rotation);

            if (newPrefab == null) yield return null;
        }

        this.isRandom = (this.SpawnCtrl.Spawner.RandomCount < this.randomLimit - 1);
    }
}
