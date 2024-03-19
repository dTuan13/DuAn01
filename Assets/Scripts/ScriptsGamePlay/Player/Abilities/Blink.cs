using UnityEngine;

public class Blink : AbilityPlayer
{
    [Header("Blink")]

    [SerializeField] protected SpawnPoint spawnPoint;

    [SerializeField] protected float valueLimit = 7f;

    [SerializeField] protected float timer = 0f;

    [SerializeField] protected float timeDelay = 1f;

    [SerializeField] protected int price = 3;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = FindObjectOfType<SpawnPoint>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoint");
    }

    protected override void UpdateAbility()
    {
        this.HidePlayer(false);

        this.timer += Time.fixedDeltaTime;

        this.percent = (float)this.timer / this.timeDelay;
        if (this.timer < this.timeDelay) return;
        this.timer = 0f;

        this.HidePlayer(true);

        Vector3 pos = this.spawnPoint.RandomPoint().position;

        while(Vector3.Distance(transform.position, pos) < this.valueLimit)
        {
            pos = this.spawnPoint.RandomPoint().position;
        }

        this.playerCtrl.transform.position = pos;
        this.isAbility = false;
    }

    protected virtual void HidePlayer(bool isHide)
    {
        this.playerCtrl.Model.gameObject.SetActive(isHide);
        this.playerCtrl.DamageReceiver.GetComponent<CapsuleCollider2D>().enabled = isHide;
        this.playerCtrl.WeponCtrl.gameObject.SetActive(isHide);
        this.playerCtrl.Inventory.gameObject.SetActive(isHide);
        this.playerCtrl.Shadow.gameObject.SetActive(isHide);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.priceAbility = this.price;
    }
}
