using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class TurretShooting : ObjectShooting
{
    [Header("Turret Shooting")]

    [SerializeField] protected CircleCollider2D circleCollider;

    [SerializeField] protected Rigidbody2D _rigidbody;

    [SerializeField] protected Transform target;

    [SerializeField] protected List<Transform> listTargets;

    [SerializeField] protected float timerDelay = 1f;

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
        this.circleCollider.radius = 3f;
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

    protected override void Update()
    {
        this.UpdateListTarget();
        this.LootAtTarget();
        base.Update();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.nameBullet = BulletSpawner.bullet_4;
        this.timeShotDelay = this.timerDelay;
    }

    protected virtual void LootAtTarget()
    {
        if (this.target == null) return;
        Vector3 diff = this.target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerDamageReceiver>() || collision.GetComponent<GunTurretDamageReceiver>()) return;

        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();

        if (damageReceiver != null) this.listTargets.Add(collision.transform);
    }

    protected override void IsShooting()
    {
        this.isShooting = (this.listTargets.Count > 0);
    }

    protected virtual void UpdateListTarget()
    {
        this.listTargets.RemoveAll(item => item.parent.gameObject.activeSelf == false);
        if (this.listTargets.Count > 0) this.target = this.listTargets[0];
    }
}
