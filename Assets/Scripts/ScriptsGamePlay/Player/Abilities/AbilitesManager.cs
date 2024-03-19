using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilitesManager : TunBehaviour
{
    private static AbilitesManager _instance;

    public static AbilitesManager Instance => _instance;

    [SerializeField] protected List<AbilityPlayer> abilities;

    protected override void Awake()
    {
        base.Awake();
        if (AbilitesManager._instance != null)
        {
            Debug.LogWarning("Only AbilitesManager allow to exists");
            return;
        }
        AbilitesManager._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilities();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilities.Count > 0) return;
        this.abilities = GetComponentsInChildren<AbilityPlayer>().ToList();
        Debug.LogWarning(transform.name + ": LoadAbilities");
    }

    public virtual AbilityPlayer GetRandomAbilities()
    {
        int index = Random.Range(0,this.abilities.Count);
        return this.abilities[index];
    }
}
