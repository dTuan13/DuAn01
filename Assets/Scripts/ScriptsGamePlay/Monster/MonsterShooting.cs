using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : ShootByDistance
{
    protected override void Update()
    {
        this.UpdateTarget();
        this.LootAtTarget();
        base.Update();
    }

    protected virtual void UpdateTarget()
    {
        this.target = FindObjectOfType<PlayerManager>().transform;
        if (this.target == null) return;
    }

    protected virtual void LootAtTarget()
    {
        if (this.target == null) return;

        Vector3 diff = this.target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
