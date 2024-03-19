using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : TunBehaviour
{
    private static PlayerManager _instance;

    public static PlayerManager Instance => _instance;

    [SerializeField] private string idPlayer;

    public string IdPlayer => idPlayer;

    [SerializeField] private PlayerCtrl playerCtrl;

    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerManager._instance != null)
        {
            Debug.LogWarning("Only PlayerManager allow to exists");
            return;
        }
        PlayerManager._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.idPlayer = PlayerPrefs.GetString(PrefConst.playerId);
    }
}
