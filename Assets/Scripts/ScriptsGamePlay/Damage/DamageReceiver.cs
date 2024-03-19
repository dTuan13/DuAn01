using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DamageReceiver : TunBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 2;
    [SerializeField] protected bool isDead = false;

    public int HP { get => hp; set => hp = value; }
    public int HpMax { get => hpMax; set => hpMax = value; }

    protected override void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int duct)
    {
        if (this.isDead) return;
        this.hp -= duct;
        if (this.hp < 0) this.hp = 0;
        this.CheckDead();
    }

    protected virtual void CheckDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected abstract void OnDead();

}
