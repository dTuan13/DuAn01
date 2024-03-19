using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_3 : BulletType
{
    [Header("Bullet_3")]

    [SerializeField] protected float flySpeed = 13;

    [SerializeField] protected int damage = 5;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.bulletCtrl.BulletFly.FlySpeed = this.flySpeed;
        this.bulletCtrl.DamageSender.Damage = this.damage;
    }
}
