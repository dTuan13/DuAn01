using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnData : TunBehaviour
{
    [Header("Player SpawnData")]

    [SerializeField] protected PlayerCtrl playerCtrl;

    [SerializeField] protected bool isSpawnData = false;

    public bool IsSpawnData { get => isSpawnData; set => isSpawnData = value; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl");

    }

    protected virtual void Update()
    {
        this.LoadData();
    }

    protected virtual void LoadData()
    {
        if (!this.playerCtrl.PlayerSO) return;

        if (this.isSpawnData) return;

        this.playerCtrl.PlayerMovement.MoveSpeed = this.playerCtrl.PlayerSO.moveSpeed;
        this.playerCtrl.Model.GetComponent<SpriteRenderer>().sprite = this.playerCtrl.PlayerSO.sprite;
        this.playerCtrl.Model.GetComponent<Animator>().runtimeAnimatorController = this.playerCtrl.PlayerSO.animator;
        this.playerCtrl.DamageReceiver.HpMax = this.playerCtrl.PlayerSO.hpMax;
        this.playerCtrl.DamageReceiver.Reborn();

        this.isSpawnData = true;
    }
}
