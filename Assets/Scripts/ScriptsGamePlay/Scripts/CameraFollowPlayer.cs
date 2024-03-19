using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : FollowTarget
{
    [Header("Camera Limit")]
    [SerializeField] protected float minX = -5f;
    [SerializeField] protected float maxX = 5f;
    [SerializeField] protected float minY = -7f;
    [SerializeField] protected float maxY = 7f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetTarget();
        this.UpdatePositionOfLimit();
    }

    protected virtual void GetTarget()
    {
        this.target = FindObjectOfType<PlayerManager>().transform;
    }

    protected virtual void UpdatePositionOfLimit()
    {
        float clampedX = Mathf.Clamp(transform.position.x, this.minX, this.maxX);
        float clampedY = Mathf.Clamp(transform.position.y, this.minY, this.maxY);

        transform.position = new Vector3(clampedX, clampedY, 1);
    }
}
