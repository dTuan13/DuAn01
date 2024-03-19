using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPlayerManager : TunBehaviour
{
    [Header("ShopPlayerManager")]

    private static ShopPlayerManager _instance;

    public static ShopPlayerManager Instance => _instance;

    [SerializeField] protected Animator animator;

    public Animator Animator => animator;

    protected override void Awake()
    {
        base.Awake();
        if (ShopPlayerManager._instance != null)
        {
            Debug.LogWarning("Only ShopPlayerManager allow to exists");
            return;
        }
        ShopPlayerManager._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("PlayerImg").GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator");
    }
}
