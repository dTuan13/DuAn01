using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExitBtn : BaseBtn
{
    [SerializeField] protected Slider loadingSlider;

    [SerializeField] protected string mainMenu = "MainMenu";

    [SerializeField] protected Transform loadingPanel;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.loadingPanel.gameObject.SetActive(false);
    }

    protected override void OnClick()
    {
        GameOverManager.Instance.ShowGameOverManager(false);
        this.loadingPanel.gameObject.SetActive(true);
        ASyncManager.Instance.LoadASync(this.loadingSlider, this.mainMenu);
    }
}
