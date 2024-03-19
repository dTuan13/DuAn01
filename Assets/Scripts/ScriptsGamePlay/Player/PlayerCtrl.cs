using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TunBehaviour
{
    [Header("PlayerCtrl")]

    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected PlayerSO playerSO;

    public PlayerSO PlayerSO => playerSO;

    [SerializeField] protected DamageReceiver damageReceiver;

    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected PlayerMovement playerMovement;

    public PlayerMovement PlayerMovement => playerMovement;

    [SerializeField] protected WeponCtrl weponCtrl;

    public WeponCtrl WeponCtrl => weponCtrl;

    [SerializeField] protected Inventory inventory;

    public Inventory Inventory => inventory;

    [SerializeField] protected Transform shadow;

    public Transform Shadow => shadow;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadShadow();
        this.LoadDamageReceiver();
        this.LoadPlayerMovement();
        this.LoadWeponCtrl();
        this.LoadInventory();
    }

    protected virtual void FixedUpdate()
    {
        this.LoadPlayerSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel");
    }

    protected virtual void LoadShadow()
    {
        if (this.shadow != null) return;
        this.shadow = transform.Find("Shadow");
        Debug.LogWarning(transform.name + ": LoadShadow");
    }

    protected virtual void LoadPlayerSO()
    {
        string resPath = "PlayerSO/" + PlayerManager.Instance.IdPlayer;
        this.playerSO = Resources.Load<PlayerSO>(resPath);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver");
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlayerMovement");
    }

    protected virtual void LoadWeponCtrl()
    {
        if (this.weponCtrl != null) return;
        this.weponCtrl = GetComponentInChildren<WeponCtrl>();
        Debug.LogWarning(transform.name + ": LoadWeponCtrl");
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory");
    }
}