using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class TrapsImpact : TrapsAbstract
{
    [SerializeField] protected CircleCollider2D circleCollider;

    public CircleCollider2D CircleCollider2D => circleCollider;

    [SerializeField] protected Rigidbody2D _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = transform.GetComponent<CircleCollider2D>();
        if (this.circleCollider == null)
        {
            Debug.LogWarning(transform.name + ": LoadCollider");
            return;
        }
        this.circleCollider.isTrigger = true;
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody2D>();
        if (this._rigidbody == null)
        {
            Debug.LogWarning(transform.name + ": LoadRigidbody");
            return;
        }
        this._rigidbody.isKinematic = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerDamageReceiver>()) return;

        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();

        if (damageReceiver == null) return;

        this.TrapsCtrl.DamageSender.Send(damageReceiver);
    }
}
