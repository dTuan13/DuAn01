using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : TunBehaviour
{
    [Header("Damage Sender")]
    [SerializeField] protected int damage = 1;

    public int Damage { get => damage; set => damage = value; }

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
