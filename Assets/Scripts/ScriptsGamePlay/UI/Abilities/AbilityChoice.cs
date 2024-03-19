using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityChoice : BaseBtn
{
    [Header("AbilityChoice")]
    [SerializeField] protected AbilityPlayer abilityPlayer;

    public AbilityPlayer AbilityPlayer { get => abilityPlayer; set => abilityPlayer = value; }

    [SerializeField] protected Image imageAbility;

    [SerializeField] protected Text price;

    [SerializeField] protected Transform xImg;

    protected override void LoadComponent()
    {
        this.LoadPriceText();
        base.LoadComponent();
        this.LoadImage();
        this.LoadxImg();
    }

    protected virtual void LoadImage()
    {
        if (this.imageAbility != null) return;
        this.imageAbility = transform.Find("ImgAbility").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage");
    }

    protected virtual void LoadPriceText()
    {
        if (this.price != null) return;
        this.price = transform.Find("Price").GetComponentInChildren<Text>();
        Debug.LogWarning(transform.name + ": LoadPriceText");
    }

    protected virtual void LoadxImg()
    {
        if (this.xImg != null) return;
        this.xImg = transform.Find("XImg");
        Debug.LogWarning(transform.name + ": LoadxImg");
    }

    protected virtual void Update()
    {
        this.SpawnDataAbility();
    }

    protected virtual void SpawnDataAbility()
    {
        if (this.abilityPlayer == null) return;
        this.imageAbility.sprite = this.abilityPlayer.Sprite;
        this.price.text = this.abilityPlayer.PriceAbility.ToString();
    }

    protected override void OnClick()
    {
        if (this.abilityPlayer == null) return;

        if (this.abilityPlayer.PriceAbility > UpdateItemPlayer.Instance.CountItem)
        {
            StartCoroutine(this.ShowCloseImg());
            return;
        }

        this.abilityPlayer.IsAbility = true;

        AbilitiesUseManager.Instance.AddAbilityUse(this.abilityPlayer);

        UpdateItemPlayer.Instance.DeductItem(this.abilityPlayer.PriceAbility);

        this.abilityPlayer = null;

        transform.gameObject.SetActive(false);
        ShopAbilities.Instance.ListChoiceRemain.Remove(this);
    }

    IEnumerator ShowCloseImg()
    {
        this.xImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.xImg.gameObject.SetActive(false);
    }
}
