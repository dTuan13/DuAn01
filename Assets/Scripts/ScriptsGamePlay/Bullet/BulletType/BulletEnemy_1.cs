using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy_1 : BulletType
{
    [Header("BulletEnemy_1")]

    [SerializeField] protected float flySpeed = 6f;

    [SerializeField] protected int damage = 4;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.bulletCtrl.BulletFly.FlySpeed = this.flySpeed;
        this.bulletCtrl.DamageSender.Damage = this.damage;
    }
}
