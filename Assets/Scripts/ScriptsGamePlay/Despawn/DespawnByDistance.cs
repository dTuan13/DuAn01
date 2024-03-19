using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]

    [SerializeField] protected float disLimit = 50f;

    [SerializeField] protected float distance = 0f;

    protected override bool CanDespawn()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;

        this.distance = Vector3.Distance(this.transform.position, camPos);
        return this.distance > this.disLimit;
    }
}
