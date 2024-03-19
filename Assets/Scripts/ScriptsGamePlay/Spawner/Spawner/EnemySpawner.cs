using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("EnemySpawner")]

    private static EnemySpawner _instance;

    public static EnemySpawner Instance => _instance;

    [SerializeField] protected string tickAppearEnemy = TickSpawner.tick_1;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner._instance != null)
        {
            Debug.LogWarning("Only EnemySpawner allow to exists");
            return;
        }
        EnemySpawner._instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.tickAppear = this.tickAppearEnemy;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform ranged = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(ranged);
        return ranged;
    }

    protected virtual void AddHPBar2Obj(Transform enemy)
    {
        MonsterCtrl monsterCtrl = enemy.GetComponent<MonsterCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, enemy.position, Quaternion.identity);

        HPBar hpBar = newHPBar.GetComponent<HPBar>();
        hpBar.MonsterCtrl = monsterCtrl;
        hpBar.FollowTarget.Target = enemy;

        newHPBar.gameObject.SetActive(true);
    }
}
