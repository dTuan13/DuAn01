using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : TunBehaviour
{
    private static PauseManager _instance;

    public static PauseManager Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (PauseManager._instance != null)
        {
            Debug.LogWarning("Only PauseManager allow to exists");
            return;
        }
        PauseManager._instance = this;
    }

    public virtual void ShowPausePanel(bool isShow)
    {
        if(isShow) Time.timeScale = 0;
        else Time.timeScale = 1;

        transform.gameObject.SetActive(isShow);
    }
}
