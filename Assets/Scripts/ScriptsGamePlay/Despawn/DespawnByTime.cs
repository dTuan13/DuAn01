using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timeOut = 0f;
    [SerializeField] protected float timeLimit = 2f;
    public float TimeLimit { set => timeLimit = value; }

    protected override void OnEnable()
    {
        this.ResetTime();
    }

    protected virtual void ResetTime()
    {
        this.timeOut = 0f;
    }
    protected override bool CanDespawn()
    {
        timeOut += Time.deltaTime;
        return timeOut > timeLimit;
    }
}
