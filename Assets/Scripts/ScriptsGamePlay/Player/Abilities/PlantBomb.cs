using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBomb : AbilityPlayer
{

    [SerializeField] protected float timerOfDelay = 0f;

    [SerializeField] protected float timeDelay = 1.2f;

    [SerializeField] protected float timeLimit = 7f;

    [SerializeField] protected float timerOfLimit = 0f;

    [SerializeField] protected int price = 6;



    protected override void UpdateAbility()
    {
        this.timerOfLimit += Time.fixedDeltaTime;

        this.percent = (float)this.timerOfLimit / this.timeLimit;

        this.timerOfDelay += Time.fixedDeltaTime;
        if (this.timerOfDelay < this.timeDelay) return;
        this.timerOfDelay = 0;


        Transform newBomb = TrapsSpawner.Instance.Spawn(TrapsSpawner.bomb_1, transform.position, Quaternion.identity);
        if (newBomb == null) return;

        if (this.timerOfLimit >= this.timeLimit)
        {
            this.isAbility = false;
            this.timerOfLimit = 0f;
            return;
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
