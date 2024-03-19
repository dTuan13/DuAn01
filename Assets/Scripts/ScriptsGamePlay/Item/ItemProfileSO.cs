using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "SO/ItemSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public int count = 1;

    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));

        foreach (ItemProfileSO item in profiles)
        {
            if (item.itemCode != itemCode) continue;
            return item;
        }
        return null;
    }
}
