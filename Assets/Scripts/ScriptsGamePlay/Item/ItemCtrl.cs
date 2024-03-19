using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : TunBehaviour
{
    [Header("ItemCtrl")]

    [SerializeField] protected ItemDespawn itemDespawn;

    public ItemDespawn ItemDespawn { get => itemDespawn; }

    [SerializeField] protected ItemProfileSO itemProfileSO;

    public ItemProfileSO ItemProfileSO => itemProfileSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
        this.LoadItemProfileSO();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
        if (this.itemDespawn == null) Debug.LogWarning("ItemCtrl: LoadItemDespawn");
    }

    protected virtual void LoadItemProfileSO()
    {
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);

        this.itemProfileSO = ItemProfileSO.FindByItemCode(itemCode);

        this.itemProfileSO.count = 1;
    }
}
