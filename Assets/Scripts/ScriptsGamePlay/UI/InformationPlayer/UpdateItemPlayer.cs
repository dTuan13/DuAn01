using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateItemPlayer : TunBehaviour
{
    private static UpdateItemPlayer _instance;

    public static UpdateItemPlayer Instance => _instance;

    [SerializeField] protected int countItem;

    public int CountItem => countItem;

    [SerializeField] protected Text itemText;

    protected override void Awake()
    {
        base.Awake();
        if (UpdateItemPlayer._instance != null)
        {
            Debug.LogWarning("Only UpdateItemPlayer allow to exists");
            return;
        }
        UpdateItemPlayer._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemText();
    }

    protected virtual void LoadItemText()
    {
        if (this.itemText != null) return;
        this.itemText = transform.GetComponentInChildren<Text>();
        Debug.LogWarning(transform.name + ": LoadItemText");
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateItemInInventory();
    }

    protected virtual void UpdateItemInInventory()
    {
        if (PlayerManager.Instance.PlayerCtrl.Inventory.Items.Count == 0) this.countItem = 0;
        else this.countItem = PlayerManager.Instance.PlayerCtrl.Inventory.Items[0].count;

        this.UpdateCountItem(this.countItem);
    }

    public virtual void UpdateCountItem(int addCount)
    {
        this.itemText.text = addCount.ToString();
    }

    public virtual void DeductItem(int countItemDeduct)
    {
        if (this.countItem < countItemDeduct) return;

        if (PlayerManager.Instance.PlayerCtrl.Inventory.Items.Count == 0) return;

        ItemCode itemCode = PlayerManager.Instance.PlayerCtrl.Inventory.Items[0].itemProfileSO.itemCode;

        PlayerManager.Instance.PlayerCtrl.Inventory.RemoveItem(itemCode, countItemDeduct);
    }
}
