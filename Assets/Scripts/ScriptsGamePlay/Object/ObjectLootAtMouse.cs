using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLootAtMouse : ObjectLootAtTarget
{
    protected virtual void Update()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.targetPosition = InputManager.Instance.MousePos;
    }
}
