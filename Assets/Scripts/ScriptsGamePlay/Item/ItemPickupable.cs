using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickupable : ItemAbstract
{
    [Header("itemPickupAble")]

    [SerializeField] protected CircleCollider2D circleCollider2D;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.radius = 0.2f;
        Debug.LogWarning(transform.name + ": LoadCollider");
    }
    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObject();
    }
}
