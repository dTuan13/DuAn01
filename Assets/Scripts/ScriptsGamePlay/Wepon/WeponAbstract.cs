using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeponAbstract : TunBehaviour
{
    [SerializeField] protected WeponCtrl weponCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeponCtrl();
    }

    protected virtual void LoadWeponCtrl()
    {
        if (this.weponCtrl != null) return;
        this.weponCtrl = transform.parent.GetComponent<WeponCtrl>();
        Debug.LogWarning(transform.name + ": LoadWeponCtrl");
    }
}
