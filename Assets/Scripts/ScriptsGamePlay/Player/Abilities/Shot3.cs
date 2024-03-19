using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot3 : AbilityPlayer
{
    [Header("Shot3")]

    [SerializeField] protected float timeLimit = 7f;

    [SerializeField] protected float timerOfLimit = 0f;

    [SerializeField] protected int price = 10;


    protected override void UpdateAbility()
    {
        this.timerOfLimit += Time.fixedDeltaTime;

        this.percent = (float)this.timerOfLimit / this.timeLimit;

        this.playerCtrl.WeponCtrl.ObjectShooting.IsShot3 = true;

        if (this.timerOfLimit >= this.timeLimit)
        {
            this.isAbility = false;
            this.timerOfLimit = 0f;
            this.playerCtrl.WeponCtrl.ObjectShooting.IsShot3 = false;
            return;
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
