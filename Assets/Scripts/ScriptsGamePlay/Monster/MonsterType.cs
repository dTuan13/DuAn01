using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterType : TunBehaviour
{
    [Header("Monster Type")]
    [SerializeField] protected MonsterCtrl monsterCtrl;

    public MonsterCtrl MonsterCtrl => monsterCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (this.monsterCtrl != null) return;
        this.monsterCtrl = GetComponent<MonsterCtrl>();
        Debug.LogWarning(transform.name + ": LoadMonsterCtrl");
    }
}
