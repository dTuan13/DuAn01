using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyImpact : BulletAbstract
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver damageReceiver;
        damageReceiver = collision.GetComponent<PlayerDamageReceiver>();

        if (damageReceiver == null) damageReceiver = collision.GetComponent<GunTurretDamageReceiver>();

        if (damageReceiver == null) return;

        this.bulletCtrl.DamageSender.Send(damageReceiver);
    }
}
