using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croshair : TunBehaviour
{
    [Header("Croshair")]

    [SerializeField] protected Vector3 target;
    protected virtual void Update()
    {
        this.MoveToTarget();
    }

    protected virtual void MoveToTarget()
    {
        this.target = InputManager.Instance.MousePos;
        this.target.z = 0;

        transform.position = this.target;
    }
}
