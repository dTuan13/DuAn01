using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopAbilities : TunBehaviour
{
    private static ShopAbilities _instance;

    public static ShopAbilities Instance => _instance;


    [SerializeField] protected List<AbilityChoice> listChoice;

    [SerializeField]  protected List<AbilityChoice> listChoiceRemain;

    public List<AbilityChoice> ListChoiceRemain => listChoiceRemain;

    [SerializeField] protected float timer = 0f;

    [SerializeField] protected float timeDelay;

    [SerializeField] protected List<AbilityPlayer> listAbility;

    protected override void Awake()
    {
        base.Awake();
        if (ShopAbilities._instance != null)
        {
            Debug.LogWarning("Only ShopAbilities allow to exists");
            return;
        }
        ShopAbilities._instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityChoice();
    }

    protected virtual void LoadAbilityChoice()
    {
        if (this.listChoice.Count > 0) return;
        this.listChoice = GetComponentsInChildren<AbilityChoice>().ToList();
        Debug.LogWarning(transform.name + ": LoadAbilityChoice");
        this.listChoiceRemain = this.listChoice.ToList();
        
    }

    protected override void Start()
    {
        base.Start();
        this.RandomAbility();
    }

    protected virtual void FixedUpdate()
    { 
        this.IsAbility();
    }

    protected virtual void IsAbility()
    {
        this.timeDelay = (float)TimerAbilities.Instance.TimerLimit;

        if (this.listChoiceRemain.Count == 0)
        {
            this.RandomAbility();
            this.listChoiceRemain = this.listChoice.ToList();
            this.timer = 0f;
        }

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeDelay) return;
        this.timer = 0;

        this.RandomAbility();
    }

    protected virtual void RandomAbility()
    {
        TimerAbilities.Instance.CountDownTimer();

        foreach (var choice in this.listChoice)
        {
            choice.gameObject.SetActive(true);

            AbilityPlayer abilityPlayer = AbilitesManager.Instance.GetRandomAbilities();

            while (this.listAbility.Contains(abilityPlayer))
            {
                abilityPlayer = AbilitesManager.Instance.GetRandomAbilities();
            }

            choice.AbilityPlayer = abilityPlayer;

            this.listAbility.Add(abilityPlayer);
        }
        this.listAbility.Clear();
    }


}
