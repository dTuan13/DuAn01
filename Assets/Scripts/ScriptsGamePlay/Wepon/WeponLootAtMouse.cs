using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponLootAtMouse : ObjectLootAtMouse
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.rotSpeed = 7f;
    }

    protected override void LootAtTarget()
    {
        base.LootAtTarget();
        
        if (transform.parent.eulerAngles.z > 90 && transform.parent.eulerAngles.z < 270)
            transform.parent.localScale = new Vector3(1, -1, 1);
        else
            transform.parent.localScale = new Vector3(1, 1, 1);
    }

}
