using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponCtrl : TunBehaviour
{
    [Header("WeponCtrl")]

    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected Transform muzzle;

    public Transform Muzzle => muzzle;

    [SerializeField] protected ObjectShooting objectShooting;

    public ObjectShooting ObjectShooting => objectShooting;

    [SerializeField] protected WeponSO weponSO;

    public WeponSO WeponSO => weponSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadMuzzle();
        this.LoadObjectShooting();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel");
    }

    protected virtual void LoadMuzzle()
    {
        if (this.muzzle != null) return;
        this.muzzle = transform.Find("Muzzle");
        Debug.LogWarning(transform.name + ": LoadMuzzle");
    }

    protected virtual void LoadObjectShooting()
    {
        if (this.objectShooting != null) return;
        this.objectShooting = GetComponentInChildren<ObjectShooting>();
        Debug.LogWarning(transform.name + ": LoadObjectShooting");
    }

    protected virtual void FixedUpdate()
    {
        this.LoadWeponSO();
    }

    protected virtual void LoadWeponSO()
    {
        string resPath = "WeponSO/" + WeponManager.Instance.WeponId;
        this.weponSO = Resources.Load<WeponSO>(resPath);
    }
}
