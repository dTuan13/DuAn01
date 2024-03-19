using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MonsterDamageSender : DamageSender
{
    [Header("Monster DamageSender")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeSender = 0.5f;
    [SerializeField] protected bool isSender = false;

    [SerializeField] protected DamageReceiver damageReceiver;

    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    public CapsuleCollider2D CapsuleCollider => capsuleCollider;


    [SerializeField] protected Rigidbody2D rb;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCapsuleCollider();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider2D>();
        this.capsuleCollider.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider");
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadRigidbody2D");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.isSender) return;

        this.damageReceiver = collision.GetComponent<PlayerDamageReceiver>();

        if (this.damageReceiver == null) this.damageReceiver = collision.GetComponent<GunTurretDamageReceiver>();

        if (this.damageReceiver == null) return;

        this.isSender = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.damageReceiver == null) return;
        if(collision.GetComponent<PlayerDamageReceiver>() != null && this.damageReceiver.GetType() == typeof(PlayerDamageReceiver)) 
            this.isSender = false;
        else if (collision.GetComponent<GunTurretDamageReceiver>() != null && this.damageReceiver.GetType() == typeof(GunTurretDamageReceiver))
            this.isSender = false;
    }

    protected virtual void FixedUpdate()
    {
        this.SendDamagePlayer();
    }

    protected virtual void SendDamagePlayer()
    {
        if (this.damageReceiver == null) return;

        if (!this.isSender) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeSender) return;
        this.timer = 0f;

        this.Send(this.damageReceiver);
    }

    public virtual void ResetValueCollider(float sizeX, float sizeY)
    {
        if (this.capsuleCollider == null) return;
        Vector3 newSize = this.capsuleCollider.size;
        newSize.x = sizeX;
        newSize.y = sizeY;

        this.capsuleCollider.size = newSize;
    }
}
