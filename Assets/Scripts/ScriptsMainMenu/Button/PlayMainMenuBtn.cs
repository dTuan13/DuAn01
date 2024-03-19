using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainMenuBtn : MainMenuBaseBtn
{
    protected override void OnClick()
    {
        this.mainMenu.gameObject.SetActive(false);
        this.shopPlayer.gameObject.SetActive(true);
        this.shopWepon.gameObject.SetActive(false);
        this.loadingPanel.gameObject.SetActive(false);
    }
}
