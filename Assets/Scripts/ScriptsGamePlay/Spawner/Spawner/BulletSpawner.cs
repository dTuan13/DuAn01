using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("Bullet Spawner")]

    private static BulletSpawner _instance;

    public static BulletSpawner Instance => _instance;

    public static string bullet_1 = "Bullet_1";
    public static string bullet_2 = "Bullet_2";
    public static string bullet_3 = "Bullet_3";
    public static string bullet_4 = "Bullet_4";


    public static string bulletEnemy_1 = "BulletEnemy_1";

    protected override void Awake()
    {
        base.Awake();
        if(BulletSpawner._instance != null)
        {
            Debug.LogWarning("Only BulletSpawner allow to exists");
            return;
        }
        BulletSpawner._instance = this;
    }
}
