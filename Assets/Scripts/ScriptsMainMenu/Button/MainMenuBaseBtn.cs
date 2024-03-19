using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainMenuBaseBtn : BaseBtn
{
    [Header("MainMenuBaseBtn")]
    [SerializeField] protected Transform mainMenu;
    [SerializeField] protected Transform shopPlayer;
    [SerializeField] protected Transform shopWepon;
    [SerializeField] protected Transform loadingPanel;
}
