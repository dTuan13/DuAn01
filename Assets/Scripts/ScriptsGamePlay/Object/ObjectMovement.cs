using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : TunBehaviour
{
    [Header("Obj Movement")]

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected float speed = 0.02f;
    public float SetSpeed { set => speed = value; }

    [SerializeField] protected float distance = 0.5f;

    public float Distance { get => distance; set => distance = value; }

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        if (this.targetPosition == null) return;
        float dis = Vector3.Distance(transform.position, this.targetPosition);
        if (dis < this.distance) return;

        Vector3 newPos = Vector3.MoveTowards(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}
