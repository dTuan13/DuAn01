using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonsterType
{
    [Header("Enemy_1")]

    [SerializeField] protected float moveSpeed = 0.02f;

    [SerializeField] protected int damageSender = 3;

    [SerializeField] protected int HpMax = 7;

    [SerializeField] protected float distance = 0.3f;

    [SerializeField] protected float sizeX = 0.5f;

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
