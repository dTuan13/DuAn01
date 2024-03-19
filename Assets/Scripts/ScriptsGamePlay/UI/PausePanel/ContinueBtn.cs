using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueBtn : BaseBtn
{
    protected override void OnClick()
    {
        this.ContinueGamePlay();
    }

    protected virtual void ContinueGamePlay()
    {
        PauseManager.Instance.ShowPausePanel(false);
    }
}
