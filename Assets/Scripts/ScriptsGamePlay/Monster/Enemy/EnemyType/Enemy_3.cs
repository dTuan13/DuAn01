using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : EnemyFlyType
{
    [Header("Enemy_3")]

    [SerializeField] protected float moveSpeed = 0.01f;

    [SerializeField] protected int damageSender = 2;

    [SerializeField] protected int HpMax = 6;

    [SerializeField] protected float distance = 3.5f;

    [SerializeField] protected float sizeX = 1f;

    [SerializeField] protected float sizeY = 0.8f;

    [SerializeField] protected float disShoot = 4f;

    [SerializeField] protected string nameBullet = BulletSpawner.bulletEnemy_1;

    [SerializeField] protected float timerShootDelay = 1f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.MonsterCtrl.ObjectMovement.SetSpeed = this.moveSpeed;

        this.enemyFlyCtrl.DamageSender.Damage = this.damageSender;
        this.enemyFlyCtrl.DamageReceiver.HpMax = this.HpMax;

        this.enemyFlyCtrl.ObjectMovement.Distance = this.distance;

        this.enemyFlyCtrl.ShootByDistance.ShootDistance = this.disShoot;
        this.enemyFlyCtrl.ShootByDistance.NameBullet = this.nameBullet;

        this.enemyFlyCtrl.ShootByDistance.TimeShootDelay = this.timerShootDelay;

        this.enemyFlyCtrl.DamageReceiver.CapsuleCollider.direction = CapsuleDirection2D.Horizontal;
        this.enemyFlyCtrl.DamageReceiver.ResetValueCollider(this.sizeX, this.sizeY);

        this.enemyFlyCtrl.DamageSender.CapsuleCollider.direction = CapsuleDirection2D.Horizontal;
        this.enemyFlyCtrl.DamageSender.ResetValueCollider(this.sizeX, this.sizeY);
    }
}
