using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : AbilityPlayer
{
    [Header("Sprint")]

    [SerializeField] protected float timeLimit = 7f;

    [SerializeField] protected float timerOfLimit = 0f;

    [SerializeField] protected float speed = 5f;

    private float normalSpeed;

    [SerializeField] protected int price = 5;


    protected override void Awake()
    {
        base.Awake();
        this.SaveNormalSpeed();
    }

    protected virtual void SaveNormalSpeed()
    {
        this.normalSpeed = this.playerCtrl.PlayerMovement.MoveSpeed;
    }

    protected override void UpdateAbility()
    {
        this.timerOfLimit += Time.deltaTime;

        this.percent = (float)this.timerOfLimit / this.timeLimit;

        this.playerCtrl.PlayerMovement.MoveSpeed = this.speed;

        if (this.timerOfLimit >= this.timeLimit)
        {
            this.timerOfLimit = 0f;
            this.playerCtrl.PlayerMovement.MoveSpeed = this.normalSpeed;
            this.isAbility = false;
        }
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
