using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Invisible : AbilityPlayer
{
    [Header("Invisible")]

    [SerializeField] protected float timeLimit = 7f;

    [SerializeField] protected float timerOfLimit = 0f;

    [SerializeField] protected int price = 4;


    protected override void UpdateAbility()
    {
        this.timerOfLimit += Time.deltaTime;

        this.playerCtrl.DamageReceiver.GetComponent<CapsuleCollider2D>().enabled = false;

        this.percent = (float)this.timerOfLimit / this.timeLimit;

        if (this.timerOfLimit >= this.timeLimit)
        {
            this.timerOfLimit = 0f;

            this.playerCtrl.DamageReceiver.GetComponent<CapsuleCollider2D>().enabled = true;

            this.isAbility = false;
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
