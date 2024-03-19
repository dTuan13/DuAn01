using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class MonsterDamagerReceiver : DamageReceiver
{
    [Header("Monster DamagerReceiver")]
    [SerializeField] protected MonsterCtrl monsterCtrl;

    public MonsterCtrl MonsterCtrl { get => monsterCtrl; }

    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    public CapsuleCollider2D CapsuleCollider => capsuleCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMonsterCtrl();
        this.LoadCapsuleCollider();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (this.monsterCtrl != null) return;
        this.monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
        Debug.LogWarning( transform.name+": LoadMonsterCtrl");
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider2D>();
        this.capsuleCollider.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider");
    }

    protected override void OnDead()
    {
        this.MonsterCtrl.Despawn.DespawnObject();
        ItemDropSpawner.Instance.Spawn(ItemDropSpawner.itemBasic, transform.position, Quaternion.identity);
    }

    public virtual void ResetValueCollider(float sizeX, float sizeY)
    {
        if (this.capsuleCollider == null) return;
        Vector3 newSize = this.capsuleCollider.size;
        newSize.x = sizeX;
        newSize.y = sizeY;

        this.capsuleCollider.size = newSize;
    }
}
