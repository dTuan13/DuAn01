using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : TunBehaviour
{
    [Header("Camera Limit")]
    [SerializeField] protected float minX = -6f;
    [SerializeField] protected float maxX = 6f;
    [SerializeField] protected float minY = -6f;
    [SerializeField] protected float maxY = 6f;

    protected virtual void FixedUpdate()
    {
        this.UpdatePositionOfLimit();
    }

    protected virtual void UpdatePositionOfLimit()
    {
        float clampedX = Mathf.Clamp(transform.position.x, this.minX, this.maxX);
        float clampedY = Mathf.Clamp(transform.position.y, this.minY, this.maxY);

        transform.position = new Vector3(clampedX, clampedY, 1);
    }
}
