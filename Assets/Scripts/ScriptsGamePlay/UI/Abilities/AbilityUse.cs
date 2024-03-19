using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUse : TunBehaviour
{
    [Header("SkillUse")]
    [SerializeField] protected Image aliblityImg;

    [SerializeField] protected Image imgFade;

    [SerializeField] protected AbilityPlayer abilityPlayer;

    public AbilityPlayer AbilityPlayer { get => abilityPlayer; set => abilityPlayer = value; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAliblityImg();
        this.LoadImgFade();
    }

    protected virtual void LoadAliblityImg()
    {
        if (this.aliblityImg != null) return;
        this.aliblityImg = transform.Find("AbilityImg").transform.GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadAliblityImg");
    }

    protected virtual void LoadImgFade()
    {
        if (this.imgFade != null) return;
        this.imgFade = transform.Find("Fade").transform.GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImgFade");
    }

    protected virtual void Update()
    {
        this.SpawnDataAbility();
    }

    protected virtual void SpawnDataAbility()
    {
        if (this.abilityPlayer == null) return;

        if(this.abilityPlayer.Percent >= 1f)
        {
            AbilitiesUseManager.Instance.DeductAbilityUse(this.abilityPlayer);
            Destroy(transform.gameObject);
            return;
        }

        this.aliblityImg.sprite = this.abilityPlayer.Sprite;
        this.imgFade.fillAmount = this.abilityPlayer.Percent;
    }
}
