using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurretSpawner : Spawner
{
    [Header("GunTurretSpawner")]

    private static GunTurretSpawner _instance;

    public static GunTurretSpawner Instance => _instance;

    public static string turret_1 = "Turret_1";

    protected override void Awake()
    {
        base.Awake();
        if (GunTurretSpawner._instance != null)
        {
            Debug.LogWarning("Only GunTurretSpawner allow to exists");
            return;
        }
        GunTurretSpawner._instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform turret = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(turret);
        return turret;
    }

    protected virtual void AddHPBar2Obj(Transform turret)
    {
        TurretCtrl turretCtrl = turret.GetComponent<TurretCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, turret.position, Quaternion.identity);

        HPBar hpBar = newHPBar.GetComponent<HPBar>();
        hpBar.MonsterCtrl = null;
        hpBar.TurretCtrl = turretCtrl;
        hpBar.FollowTarget.Target = turret;

        newHPBar.gameObject.SetActive(true);

    }
}
