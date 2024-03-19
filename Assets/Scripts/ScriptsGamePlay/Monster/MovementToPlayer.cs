using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPlayer : ObjectMovement
{
    protected virtual void Update()
    {
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        this.targetPosition = FindObjectOfType<PlayerManager>().transform.position;
        if (this.targetPosition == null)    return;
    }
}
