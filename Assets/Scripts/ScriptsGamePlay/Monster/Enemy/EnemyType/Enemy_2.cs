using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonsterType
{
    [Header("Enemy_2")]

    [SerializeField] protected float moveSpeed = 0.015f;

    [SerializeField] protected int damageSender = 5;

    [SerializeField] protected int HpMax = 9;

    [SerializeField] protected float distance = 0.4f;

    [SerializeField] protected float sizeX = 0.7f;

    [SerializeField] protected float sizeY = 0.8f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.MonsterCtrl.ObjectMovement.SetSpeed = this.moveSpeed;

        this.monsterCtrl.DamageSender.Damage = this.damageSender;
        this.monsterCtrl.DamageReceiver.HpMax = this.HpMax;

        this.monsterCtrl.ObjectMovement.Distance = this.distance;

        this.monsterCtrl.DamageReceiver.ResetValueCollider(this.sizeX, this.sizeY);
        this.monsterCtrl.DamageSender.ResetValueCollider(this.sizeX, this.sizeY);
    }
}
