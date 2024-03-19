using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : BulletAbstract
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerDamageReceiver>() || collision.GetComponent<GunTurretDamageReceiver>()) return;

        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();

        if (damageReceiver == null) return;

        this.bulletCtrl.DamageSender.Send(damageReceiver);
    }
}
