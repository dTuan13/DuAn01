using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TunBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.OnEnable();
    }

    protected virtual void Awake()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void LoadComponent()
    {

    }

    protected virtual void ResetValue()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void OnEnable()
    {
        this.ResetValue();
    }
}
