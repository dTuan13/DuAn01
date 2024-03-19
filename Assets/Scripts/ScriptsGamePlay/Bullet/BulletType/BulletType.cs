using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletType : TunBehaviour
{
    [Header("Bullet Type")]
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
        this.bulletCtrl = GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl");
    }
}
