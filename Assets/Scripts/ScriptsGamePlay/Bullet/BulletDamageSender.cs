using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [Header("Bullet Damage Sender")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    [SerializeField] protected bool isAPI;

    public bool IsAPI { get => isAPI; set => isAPI = value; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        if (this.bulletCtrl == null) Debug.LogWarning( transform.name + ": LoadBulletCtrl");
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.BulletCtrl.Despawn.DespawnObject();
    }
}
