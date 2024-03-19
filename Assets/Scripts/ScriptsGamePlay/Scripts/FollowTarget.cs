using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : TunBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Transform target;

    public Transform Target { get => target; set => target = value; }

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, this.speed * Time.fixedDeltaTime);
    }
}
