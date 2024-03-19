using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAbilities : TunBehaviour
{
    private static TimerAbilities _instance;

    public static TimerAbilities Instance => _instance;

    [SerializeField] protected Text timerText;

    [SerializeField] protected int timerLimit = 10;

    public int TimerLimit => timerLimit;

    [SerializeField] protected int timer;

    [SerializeField] protected bool isRunning;

    protected override void Awake()
    {
        base.Awake();
        if (TimerAbilities._instance != null)
        {
            Debug.LogWarning("Only TimerAbilities allow to exists");
            return;
        }
        TimerAbilities._instance = this;

        this.ResetTimer();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTimerText();
    }

    protected virtual void LoadTimerText()
    {
        if (this.timerText != null) return;
        this.timerText = GetComponent<Text>();
        Debug.LogWarning(transform.name + ": LoadTimerText");
    }

    protected virtual void ResetTimer()
    {
        this.timer = this.timerLimit;
        this.isRunning = true;
    }

    public virtual void CountDownTimer()
    {
        if (!this.isRunning) return;
        this.ResetTimer();
        StopAllCoroutines();
        StartCoroutine(this.Countdown());
    }

    private IEnumerator Countdown()
    {
        while (this.timer > 0)
        {
            this.UpdateTimerText(this.timer);

            yield return new WaitForSeconds(1f);

            this.timer -= 1;
        }
    }

    protected void UpdateTimerText(int currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime  / 60);
        int seconds = Mathf.FloorToInt(currentTime  - minutes * 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    public virtual void StopTimer()
    {
        isRunning = false;
        StopAllCoroutines();
    }
}
