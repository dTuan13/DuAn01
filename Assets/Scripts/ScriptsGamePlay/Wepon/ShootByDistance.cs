using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByDistance : ObjectShooting
{
    [Header("ShootByDistance")]
    [SerializeField] protected Transform target;

    [SerializeField] protected float distance = Mathf.Infinity;

    [SerializeField] protected float shootDistance = 3f;

    public float ShootDistance { get => shootDistance; set => shootDistance = value; }
    protected override void IsShooting()
    {
        if(this.target == null)
        {
            this.isShooting = false;
            return;
        }
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = this.distance < this.shootDistance;
    }
}
