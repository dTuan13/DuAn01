using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponManager : TunBehaviour
{
    private static WeponManager _instance;

    public static WeponManager Instance => _instance;

    [SerializeField] private string weponId;

    public string WeponId => weponId;

    protected override void Awake()
    {
        base.Awake();
        if (WeponManager._instance != null)
        {
            Debug.LogWarning("Only WeponManager allow to exists");
            return;
        }
        WeponManager._instance = this;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.weponId = PlayerPrefs.GetString(PrefConst.weponId);
    }
}
