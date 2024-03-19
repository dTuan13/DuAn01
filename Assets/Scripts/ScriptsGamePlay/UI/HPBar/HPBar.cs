using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : TunBehaviour
{
    [SerializeField] protected SliderHP sliderHP;

    [SerializeField] protected MonsterCtrl monsterCtrl;

    public MonsterCtrl MonsterCtrl { get => monsterCtrl; set => monsterCtrl = value; }

    [SerializeField] protected TurretCtrl turretCtrl;

    public TurretCtrl TurretCtrl { get => turretCtrl; set => turretCtrl = value; }

    [SerializeField] protected FollowTarget followTarget;

    public FollowTarget FollowTarget { get => followTarget; set => followTarget = value; }

    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        if (this.spawner == null)
        {
            Debug.Log(transform.name + ": LoadSpawner", gameObject);
            return;
        }
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        if (this.followTarget == null)
        {
            Debug.Log(transform.name + ": LoadFollowTarget", gameObject);
            return;
        }
    }

    protected virtual void LoadSlider()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        if (this.sliderHP == null)
        {
            Debug.Log(transform.name + ": LoadSlider", gameObject);
            return;
        }
    }

    protected virtual void HPShowing()
    {
        if (this.monsterCtrl == null && this.turretCtrl == null) return;

        bool isDead;
        int hp, hpMax;

        if (this.monsterCtrl != null )
        {
            isDead = this.monsterCtrl.DamageReceiver.IsDead();
            if (isDead)
            {
                this.spawner.Despawn(transform);
                return;
            }
            hp = this.monsterCtrl.DamageReceiver.HP;
            hpMax = this.monsterCtrl.DamageReceiver.HpMax;
            this.followTarget.Target = this.monsterCtrl.transform;
        }
        else
        {
            isDead = this.turretCtrl.DamageReceiver.IsDead();
            if (isDead)
            {
                this.spawner.Despawn(transform);
                return;
            }
            hp = this.turretCtrl.DamageReceiver.HP;
            hpMax = this.turretCtrl.DamageReceiver.HpMax;
            this.followTarget.Target = this.turretCtrl.transform;

        }

        this.sliderHP.Hp = hp;
        this.sliderHP.HpMax = hpMax;
    }
}
