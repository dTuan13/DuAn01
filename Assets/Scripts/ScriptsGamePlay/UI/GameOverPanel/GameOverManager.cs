using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : TunBehaviour
{
    private static GameOverManager _instance;

    public static GameOverManager Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (GameOverManager._instance != null)
        {
            Debug.LogWarning("Only GameOverManager allow to exists");
            return;
        }
        GameOverManager._instance = this;
    }

    public virtual void ShowGameOverManager(bool isShow)
    {
        if (isShow) Time.timeScale = 0;
        else Time.timeScale = 1;

        transform.gameObject.SetActive(isShow);
    }
}
