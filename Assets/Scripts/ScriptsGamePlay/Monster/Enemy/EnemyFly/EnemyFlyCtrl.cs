using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyCtrl : MonsterCtrl
{
    [Header("Enemy FlyCtrl")]
    [SerializeField] protected ShootByDistance shootByDistance;

    public ShootByDistance ShootByDistance => shootByDistance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootByDistance();
    }

    protected virtual void LoadShootByDistance()
    {
        if (this.shootByDistance != null) return;
        this.shootByDistance = GetComponentInChildren<ShootByDistance>();
        Debug.LogWarning(transform.name + ": LoadShootByDistance");
    }
}
