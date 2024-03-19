using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointFollowPlayer : SpawnpointFollowTarget
{
    protected virtual void FixedUpdate()
    {
        this.UpdateTarget();
    }

    protected virtual void UpdateTarget()
    {
        this.target = FindObjectOfType<PlayerManager>().transform.position;
    }
}
