using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextShopWeponBtn : MainMenuBaseBtn
{
    protected override void OnClick()
    {
        this.shopWepon.gameObject.SetActive(true);
        this.shopPlayer.gameObject.SetActive(false);
        this.mainMenu.gameObject.SetActive(false);
        this.loadingPanel.gameObject.SetActive(false);
    }
}
