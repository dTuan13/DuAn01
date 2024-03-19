using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_2 : BulletType
{
    [Header("Bullet_2")]

    [SerializeField] protected float flySpeed = 10;

    [SerializeField] protected int damage = 6;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.bulletCtrl.BulletFly.FlySpeed = this.flySpeed;
        this.bulletCtrl.DamageSender.Damage = this.damage;
    }
}
