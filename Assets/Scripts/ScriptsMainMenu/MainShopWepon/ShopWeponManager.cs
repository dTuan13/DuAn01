using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeponManager : TunBehaviour
{
    [Header("ShopWeponManager")]

    private static ShopWeponManager _instance;

    public static ShopWeponManager Instance => _instance;

    [SerializeField] protected Image img;

    public Image Image => img;

    protected override void Awake()
    {
        base.Awake();
        if (ShopWeponManager._instance != null)
        {
            Debug.LogWarning("Only ShopWeponManager allow to exists");
            return;
        }
        ShopWeponManager._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.img != null) return;
        this.img = transform.Find("WeponImg").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage");
    }
}
