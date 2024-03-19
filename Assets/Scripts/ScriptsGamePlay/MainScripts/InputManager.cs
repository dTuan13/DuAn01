using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : TunBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance => _instance;

    [SerializeField] private float onHorizontal;

    public float OnHorizontal => onHorizontal;

    [SerializeField] private float onVertical;

    public float OnVertical => onVertical;

    [SerializeField] private Vector3 mousePos;

    public Vector3 MousePos => mousePos;

    [SerializeField] private bool onFire1;

    public bool OnFire1 => onFire1;

    protected override void Awake()
    {
        base.Awake();
        if(InputManager._instance != null)
        {
            Debug.LogWarning("Only InputManager allow to exists");
            return;
        }
        InputManager._instance = this;
    }

    protected virtual void Update()
    {
        this.GetMousePos();
        this.GetMouseDown();
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateHorizontal();
        this.UpdateVertical();
    }

    protected virtual void UpdateHorizontal()
    {
        this.onHorizontal = Input.GetAxisRaw("Horizontal");
    }

    protected virtual void UpdateVertical()
    {
        this.onVertical = Input.GetAxisRaw("Vertical");
    }

    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFire1 = Input.GetAxisRaw("Fire1") == 1f;
    }
}
