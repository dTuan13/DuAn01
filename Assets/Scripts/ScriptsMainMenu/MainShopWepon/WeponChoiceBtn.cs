using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeponChoiceBtn : BaseBtn
{
    [SerializeField] protected int id;

    [SerializeField] protected Image img;

    public Image Image => img;

    protected override void OnClick()
    {
        ShopWeponManager.Instance.Image.sprite = this.img.sprite;
        PlayerPrefs.SetString(PrefConst.weponId, "Wepon0" + this.id);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.img != null) return;
        this.img = transform.Find("Image").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage");

        
    }
}
