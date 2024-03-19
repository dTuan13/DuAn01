using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SuckItem : AbilityPlayer
{
    [Header("SuckItem")]

    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody2D { get => _rigidbody; set => _rigidbody = value; }

    [SerializeField] protected float addSuck = 10f;

    [SerializeField] protected List<Transform> items;

    [SerializeField] protected float distanceSuck = 0.5f;

    [SerializeField] protected float timer = 0f;

    [SerializeField] protected float timeLimit = 2f;

    [SerializeField] protected float normalRadius = 0.9f;

    [SerializeField] protected int price = 6;


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
        this.circleCollider.radius = this.normalRadius;
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
        ItemPickupable itemPickupable = collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        this.items.Add(itemPickupable.transform.parent);

    }

    protected virtual void Update()
    {
        this.MoveItem();
        this.UpdateItems();
    }

    protected virtual void MoveItem()
    {
        foreach(var item in this.items)
        {
            item.position = Vector3.MoveTowards(item.position, transform.position, this.addSuck * Time.deltaTime);

            float distance = Vector3.Distance(item.position, transform.position);

            if (distance < this.distanceSuck)
            {
                continue;
            };
        }
        
    }

    protected virtual void UpdateItems()
    {
        this.items.RemoveAll(item => item.gameObject.activeSelf == false);
    }
    protected override void UpdateAbility()
    {
        this.circleCollider.radius = 50f;

        this.timer += Time.fixedDeltaTime;

        this.percent = (float)this.timer / this.timeLimit;

        if (this.timer < this.timeLimit) return;
        this.timer = 0;
        this.isAbility = false;
        this.circleCollider.radius = this.normalRadius;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
