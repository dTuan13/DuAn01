using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : FollowTarget
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetTarget();
    }

    protected virtual void GetTarget()
    {
        this.target = FindObjectOfType<PlayerManager>().transform;
    }
}
