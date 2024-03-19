using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : TunBehaviour
{
    [Header("BombController")]

    [SerializeField] protected BombCtrl bombCtrl;

    public BombCtrl BombCtrl { get => bombCtrl; }

    [SerializeField] protected float timer = 0f;

    [SerializeField] protected float timeExplode = 2.9f;

    [SerializeField] protected int bombDamage = 5;

    [SerializeField] protected float timeDespawn = 3f;

    [SerializeField] protected float radiusCollider = 0.7f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBombCtrl();
    }

    protected virtual void LoadBombCtrl()
    {
        if (this.bombCtrl != null) return;
        this.bombCtrl = transform.GetComponent<BombCtrl>();
        if (this.bombCtrl == null) Debug.LogWarning(transform.name + ": LoadBombCtrl");
    }

    protected virtual void FixedUpdate()
    {
        this.BombExploding();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitValue();
    }

    protected virtual void InitValue()
    {
        this.timer = 0f;
        this.bombCtrl.FX.gameObject.SetActive(false);
        this.BombCtrl.TrapsImpact.gameObject.SetActive(false);
        this.bombCtrl.Model.gameObject.SetActive(true);
    }

    protected virtual void BombExploding()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeExplode) return;
        this.timer = 0;

        this.bombCtrl.Model.gameObject.SetActive(false);
        this.BombCtrl.TrapsImpact.gameObject.SetActive(true);
        this.BombCtrl.FX.gameObject.SetActive(true);

    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.BombCtrl.DamageSender.Damage = this.bombDamage;
        this.bombCtrl.Despawn.TimeLimit = this.timeDespawn;
        this.bombCtrl.TrapsImpact.CircleCollider2D.radius = this.radiusCollider;
    }
}
