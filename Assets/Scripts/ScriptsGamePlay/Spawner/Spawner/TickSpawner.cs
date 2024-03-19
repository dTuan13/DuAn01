using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSpawner : Spawner
{
    [Header("TickSpawner")]

    private static TickSpawner _instance;

    public static TickSpawner Instance => _instance;

    public static string tick_1 = "Tick_1";

    protected override void Awake()
    {
        base.Awake();
        if (TickSpawner._instance != null)
        {
            Debug.LogWarning("Only TickSpawner allow to exists");
            return;
        }
        TickSpawner._instance = this;
    }
}
