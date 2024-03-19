using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallGunTurret : AbilityPlayer
{
    [Header("RecallGunTurret")]

    [SerializeField] protected float timer = 0;

    [SerializeField] protected float timeLimit = 0.5f;

    [SerializeField] protected int price = 8;

    protected override void UpdateAbility()
    {
        this.timer += Time.fixedDeltaTime;
        this.percent = (float)this.timer / this.timeLimit;

        if (this.timer < this.timeLimit) return;
        this.timer = 0;

        Transform newTurret = GunTurretSpawner.Instance.Spawn(GunTurretSpawner.turret_1, transform.position, Quaternion.identity);
        if (newTurret == null) return;

        this.timer = 0;
        this.isAbility = false;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
