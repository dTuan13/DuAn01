using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : BaseBtn
{
    [SerializeField] protected PauseManager pauseManager;
     protected override void OnClick()
    {
        this.IsPause();
    }

    protected virtual void IsPause()
    {
        this.pauseManager.ShowPausePanel(true);
    }
}
