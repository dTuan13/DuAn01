using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected CircleCollider2D circleCollider;
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
        this.circleCollider.radius = 0.5f;
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody2D>();
        if (this._rigidbody == null)
        {
            Debug.LogWarning(transform.name +": LoadRigidbody");
            return;
        }
        this._rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable = collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.ItemCtrl.ItemProfileSO.itemCode;

        this.inventory.AddItem(itemCode);

        itemPickupable.Picked();
    }
}
