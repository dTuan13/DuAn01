using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParentFly : TunBehaviour
{
    [Header("Object Parent Fly")]

    [SerializeField] protected float flySpeed = 8f;

    public float FlySpeed { get => flySpeed; set => flySpeed = value; }

    [SerializeField] protected Vector3 direction = Vector3.right;

    protected virtual void Update()
    {
        this.ParentFly();
    }

    protected virtual void ParentFly()
    {
        transform.parent.Translate(this.direction * this.flySpeed * Time.deltaTime);
    }


}
