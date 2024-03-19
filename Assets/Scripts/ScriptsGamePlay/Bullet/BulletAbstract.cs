using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : TunBehaviour
{
    [Header("Bullet Abstract")]

    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl");
    }
}
