using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TunBehaviour
{
    [Header("GameManager")]
    [SerializeField] protected Transform mainMenu;
    [SerializeField] protected Transform shopPlayer;
    [SerializeField] protected Transform shopWepon;
    [SerializeField] protected Transform loadingPanel;

    protected override void OnEnable()
    {
        this.mainMenu.gameObject.SetActive(true);
        this.shopPlayer.gameObject.SetActive(false);
        this.shopWepon.gameObject.SetActive(false);
        this.loadingPanel.gameObject.SetActive(false);

        PlayerPrefs.SetString(PrefConst.weponId, "Wepon01");
        PlayerPrefs.SetString(PrefConst.playerId, "Player01");
    }


}
