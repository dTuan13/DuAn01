using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_4 : BulletType
{
    [Header("Bullet_4")]

    [SerializeField] protected float flySpeed = 7;

    [SerializeField] protected int damage = 4;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.bulletCtrl.BulletFly.FlySpeed = this.flySpeed;
        this.bulletCtrl.DamageSender.Damage = this.damage;
    }
}
