using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryAbstract : TunBehaviour
{
    [Header("Inventor Abstract")]

    [SerializeField] protected Inventory inventory;

    public Inventory Inventory => inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory");
    }
}
