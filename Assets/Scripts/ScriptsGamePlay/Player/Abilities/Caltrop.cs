using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caltrop : AbilityPlayer
{
    [Header("Caltrop")]

    [SerializeField] protected bool isMove;

    [SerializeField] protected float timerOfDelay = 0f;

    [SerializeField] protected float timeDelay = 0.1f;

    [SerializeField] protected float timeLimit = 7f;

    [SerializeField] protected float timerOfLimit = 0f;

    [SerializeField] protected int price = 5;


    protected override void UpdateAbility()
    {
        this.timerOfLimit += Time.fixedDeltaTime;

        this.percent = (float)this.timerOfLimit / this.timeLimit;

        if(this.timerOfLimit >= this.timeLimit)
        {
            this.isAbility = false;
            this.timerOfLimit = 0f;
            return;
        }

        this.isMove = (InputManager.Instance.OnHorizontal != 0) || (InputManager.Instance.OnVertical != 0);

        if (!this.isMove) return;

        this.timerOfDelay += Time.fixedDeltaTime;
        if (this.timerOfDelay < this.timeDelay) return;
        this.timerOfDelay = 0;

        Transform newPrefab = TrapsSpawner.Instance.Spawn(TrapsSpawner.caltrop_1, transform.position, Quaternion.identity);
        if (newPrefab == null) return;

    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
