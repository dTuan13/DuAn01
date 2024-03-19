using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityPlayer : PlayerAbstract
{
    [Header("AbilityPlayer")]

    [SerializeField] protected bool isAbility;

    public bool IsAbility { get => isAbility; set => isAbility = value; }

    [SerializeField] protected int priceAbility;

    public int PriceAbility => priceAbility;

    [SerializeField] protected Sprite sprite;


    public Sprite Sprite => sprite;

    [SerializeField] protected float percent;

    public float Percent => percent;

    protected virtual void FixedUpdate()
    {
        this.CanAbility();
    }

    protected virtual void CanAbility()
    {
        if (!this.isAbility) return;
        this.UpdateAbility();
    }

    protected abstract void UpdateAbility();
}
