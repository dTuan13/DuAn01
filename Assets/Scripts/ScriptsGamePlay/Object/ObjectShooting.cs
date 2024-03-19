using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooting : TunBehaviour
{
    [Header("Object Shooting")]

    [SerializeField] protected bool isShooting = false;

    public bool GetIsShooting => isShooting;

    [SerializeField] protected float timer = 0f;

    [SerializeField] protected float timeShotDelay = 0.3f;

    public float TimeShootDelay { get => timeShotDelay; set => timeShotDelay = value; }


    [SerializeField] protected string nameBullet;

    public string NameBullet { get => nameBullet; set => nameBullet = value; }

    [SerializeField] protected bool isShot3;

    public bool IsShot3 { get => isShot3; set => isShot3 = value; }

    [SerializeField] protected Transform shot2Pos;

    [SerializeField] protected Transform shot3Pos;

    protected virtual void Update()
    {
        this.IsShooting();
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShotPos();
    }

    protected virtual void LoadShotPos()
    {
        if (this.shot2Pos != null && this.shot3Pos != null) return;
        this.shot2Pos = transform.Find("Shot2Forward");
        this.shot3Pos = transform.Find("Shot3Forward");
        Debug.LogWarning(transform.name + ": LoadShotPos");
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeShotDelay) return;
        this.timer = 0f;

        Transform bullet = BulletSpawner.Instance.Spawn(this.nameBullet, transform.position, transform.rotation);
        if (bullet == null) return;

        if(this.isShot3)
        {
            Transform bullet2 = BulletSpawner.Instance.Spawn(this.nameBullet, this.shot2Pos.position, this.shot2Pos.rotation);
            if (bullet2 == null) return;

            Transform bullet3 = BulletSpawner.Instance.Spawn(this.nameBullet, this.shot3Pos.position, this.shot3Pos.rotation);
            if (bullet3 == null) return;
        }
    }

    protected abstract void IsShooting();
}
