using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyType : MonsterType
{
    [Header("EnemyFlyType")]
    [SerializeField] protected EnemyFlyCtrl enemyFlyCtrl;

    public EnemyFlyCtrl EnemyFlyCtrl => enemyFlyCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyFlyCtrl();
    }

    protected virtual void LoadEnemyFlyCtrl()
    {
        if (this.enemyFlyCtrl != null) return;
        this.enemyFlyCtrl = GetComponent<EnemyFlyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyFlyCtrl");
    }
}
