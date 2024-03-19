using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectLootAtTarget : TunBehaviour
{
    [Header("Obj Look At Target")]

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected float rotSpeed = 3f;

    public float SetSpeed { set => rotSpeed = value; }

    protected virtual void FixedUpdate()
    {
        this.LootAtTarget();
    }

    protected virtual void LootAtTarget()
    {
        if (this.targetPosition == null) return;

        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;

        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);

        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
    }
}
