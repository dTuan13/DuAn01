using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : TunBehaviour
{
    [Header("GameCtrl")]

    private static GameCtrl _instance;

    public static GameCtrl Instance => _instance;

    [SerializeField] private Camera _camera;

    public Camera MainCamera => _camera;

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl._instance != null)
        {
            Debug.LogWarning("Only GameCtrl allow to exists");
            return;
        }
        GameCtrl._instance = this;
    }

    protected override void LoadComponent()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this._camera != null) return;
        this._camera = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera");
    }
}
