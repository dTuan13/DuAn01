using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRegen : AbilityPlayer
{
    [Header("HpRegen")]

    [SerializeField] protected int hp = 50;

    [SerializeField] protected float timer = 0f;

    [SerializeField] protected float timeDelay = 0.03f;

    private int stepHp = 2;

    private int countHp = 0;

    [SerializeField] protected int price = 12;


    protected override void UpdateAbility()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeDelay) return;
        this.timer = 0;

        this.playerCtrl.DamageReceiver.Add(this.stepHp);

        this.countHp += this.stepHp;

        this.percent = (float)this.countHp / this.hp;

        if(this.countHp == this.hp)
        {
            this.isAbility = false;
            this.countHp = 0;
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }

}
