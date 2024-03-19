using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_1 : BulletType
{
    [Header("Bullet_1")]

    [SerializeField] protected float flySpeed = 11f;

    [SerializeField] protected int damage = 5;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.bulletCtrl.BulletFly.FlySpeed = this.flySpeed;
        this.bulletCtrl.DamageSender.Damage = this.damage;
    }
}
