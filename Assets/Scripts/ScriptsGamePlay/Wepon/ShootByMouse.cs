using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByMouse : ObjectShooting
{
    protected override void IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFire1;
    }
}
