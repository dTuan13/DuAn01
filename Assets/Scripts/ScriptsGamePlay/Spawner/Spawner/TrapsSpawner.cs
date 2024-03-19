using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsSpawner : Spawner
{
    [Header("TrapsSpawner")]

    private static TrapsSpawner _instance;

    public static TrapsSpawner Instance => _instance;

    public static string bomb_1 = "Bomb_1";
    public static string caltrop_1 = "Caltrop_1";

    protected override void Awake()
    {
        base.Awake();
        if (TrapsSpawner._instance != null)
        {
            Debug.LogWarning("Only TrapsSpawner allow to exists");
            return;
        }
        TrapsSpawner._instance = this;
    }
}
