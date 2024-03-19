using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceBtn : BaseBtn
{
    [SerializeField] protected int id;

    protected override void OnClick()
    {
        ShopPlayerManager.Instance.Animator.SetInteger("State", this.id);
        PlayerPrefs.SetString(PrefConst.playerId, "Player0" + this.id);
    }
}
