using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerDamageReceiver : DamageReceiver
{
    [Header("PlayerDamageReceiver")]

    [SerializeField] protected bool isAnimationDeaded = false;

    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    public CapsuleCollider2D CapsuleCollider => capsuleCollider;

    [SerializeField] protected GameOverManager gameOverManager;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCapsuleCollider();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider2D>();
        this.capsuleCollider.isTrigger = true;
        this.ResetValueCollider(0.7f, 1f);
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider");
    }

    protected virtual void Update()
    {
        this.UpdateValueHp();
        this.AnimationOnDead();
    }

    protected virtual void AnimationOnDead()
    {
        if(this.isDead && !this.isAnimationDeaded)
        {
            PlayerManager.Instance.PlayerCtrl.Model.transform.GetComponent<Animator>().SetInteger("State", 2);
            this.isAnimationDeaded = true;
        }
    }
    protected override void OnDead()
    {
        this.gameOverManager.ShowGameOverManager(true);
    }

    protected virtual void UpdateValueHp()
    {
        UpdateHpPlayer.Instance.UpdateValueSliderHpPlayer(this.hp, this.hpMax);
    }

    protected virtual void ResetValueCollider(float sizeX, float sizeY)
    {
        if (this.capsuleCollider == null) return;
        Vector3 newSize = this.capsuleCollider.size;
        newSize.x = sizeX;
        newSize.y = sizeY;

        this.capsuleCollider.size = newSize;
    }
}
