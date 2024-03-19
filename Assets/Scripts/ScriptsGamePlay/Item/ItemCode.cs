using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCode 
{
    NoItem = 0,

    ItemBasic = 1,
}

public class ItemCodeParser
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            ItemCode itemCode = (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
            return itemCode;
        }
        catch (System.ArgumentException e)
        {
            Debug.Log(e.Message);
            return ItemCode.NoItem;
        }
    }
}
