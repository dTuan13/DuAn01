using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonsterType
{
    [Header("Enemy_1")]

    [SerializeField] protected float moveSpeed = 0.005f;

    [SerializeField] protected int damageSender = 5;

    [SerializeField] protected int HpMax = 20;

    [SerializeField] protected float distance = 0.3f;

    [SerializeField] protected float sizeX = 1.2f;

    [SerializeField] protected float sizeY = 1.5f;
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
