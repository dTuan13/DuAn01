using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilitiesUseManager : TunBehaviour
{
    private static AbilitiesUseManager _instance;

    public static AbilitiesUseManager Instance => _instance;

    [SerializeField] protected List<AbilityUse> listAbilityUse;

    [SerializeField] protected AbilityUse abi;

    protected override void Awake()
    {
        base.Awake();
        if (AbilitiesUseManager._instance != null)
            Debug.LogWarning("Only AbilitiesUseManager allow to exists");
        AbilitiesUseManager._instance = this;
    }

    protected virtual void Update()
    {
        this.LoadListAbilityUse();
    }

    protected virtual void LoadListAbilityUse()
    {
        this.listAbilityUse = transform.GetComponentsInChildren<AbilityUse>().ToList();
    }

    public virtual void AddAbilityUse(AbilityPlayer abilityPlayer)
    {
        if (abilityPlayer == null) return;

        this.DeductAbilityUse(abilityPlayer);

        AbilityUse newAbility = Instantiate(this.abi, Vector3.zero, Quaternion.identity);

        newAbility.transform.SetParent(this.transform);

        newAbility.AbilityPlayer = abilityPlayer;

        newAbility.transform.localScale = Vector3.one;

        newAbility.transform.localPosition = Vector3.zero;

        this.listAbilityUse.Add(newAbility);
    }

    public virtual void DeductAbilityUse(AbilityPlayer abilityPlayer)
    {
        foreach(var ability in this.listAbilityUse)
        {
            if (ability.AbilityPlayer != abilityPlayer) continue;
            Destroy(ability.gameObject);
        }
    }

}
