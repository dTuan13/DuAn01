using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponSpawnData : TunBehaviour
{
    [Header("WeponSpawnData")]

    [SerializeField] protected WeponCtrl weponCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeponCtrl();
    }

    protected virtual void LoadWeponCtrl()
    {
        if (this.weponCtrl != null) return;
        this.weponCtrl = GetComponent<WeponCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl");
    }

    protected virtual void Update()
    {
        this.LoadData();
    }

    protected virtual void LoadData()
    {
        if (!this.weponCtrl.WeponSO) return;

        this.weponCtrl.Model.GetComponent<SpriteRenderer>().sprite = this.weponCtrl.WeponSO.sprite;
        this.weponCtrl.ObjectShooting.NameBullet = this.weponCtrl.WeponSO.nameBullet.ToString();
    }
}
