using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGameBtn : BaseBtn
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
