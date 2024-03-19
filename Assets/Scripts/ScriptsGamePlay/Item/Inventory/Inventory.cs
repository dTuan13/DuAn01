using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : TunBehaviour
{
    [Header("Inventory")]

    [SerializeField] protected List<ItemInventory> items;

    public List<ItemInventory> Items => items;

    public virtual void AddItem(ItemCode itemCode)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        ItemInventory itemExist = this.GetItemInventory(itemProfile);

        if (itemExist == null)
        {
            itemExist = this.CreateItemInventory(itemProfile);
            this.items.Add(itemExist);
        }

        itemExist.count += 1;
        
    }

    public virtual void RemoveItem(ItemCode itemCode, int countRemove)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        ItemInventory itemExist = this.GetItemInventory(itemProfile);

        if (itemExist == null) return;

        itemExist.count -= countRemove;

        this.UpdateItemInventory();
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemInventory(ItemProfileSO itemProfileSO)
    {
        foreach(ItemInventory item in this.items)
        {
            if (item.itemProfileSO == itemProfileSO) return item;
        }
        return null;
    }

    protected virtual ItemInventory CreateItemInventory(ItemProfileSO itemProfileSO)
    {
        ItemInventory newItem = new ItemInventory();
        newItem.itemProfileSO = itemProfileSO;
        newItem.count = 0;
        return newItem;
    }

    protected virtual void UpdateItemInventory()
    {
        this.items.RemoveAll(item => item.count <= 0);
    }

}
