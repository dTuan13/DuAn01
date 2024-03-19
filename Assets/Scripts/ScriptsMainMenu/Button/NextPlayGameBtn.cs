using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextPlayGameBtn : MainMenuBaseBtn
{
    [Header("Next PlayGameBtn")]
    [SerializeField] protected Slider loadingSlider;

    [SerializeField] protected string gamePlay = "GamePlay";

    protected override void OnClick()
    {
        this.mainMenu.gameObject.SetActive(false);
        this.shopPlayer.gameObject.SetActive(false);
        this.shopWepon.gameObject.SetActive(false);
        this.loadingPanel.gameObject.SetActive(true);

        ASyncManager.Instance.LoadASync(this.loadingSlider, this.gamePlay);
    }

    

    
}
