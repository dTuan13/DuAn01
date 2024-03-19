using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    [Header("ItemDropSpawner")]

    private static ItemDropSpawner _instance;

    public static ItemDropSpawner Instance => _instance;

    public static string itemBasic = "ItemBasic";
    public static string itemBlood = "ItemBlood";
    public static string itemSpeed = "ItemSpeed";

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner._instance != null)
        {
            Debug.LogWarning("Only ItemDropSpawner allow to exists");
            return;
        }
        ItemDropSpawner._instance = this;
    }
}
