using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPlay : TunBehaviour
{
    private static TimerPlay _instance;

    public static TimerPlay Instance => _instance;

    [SerializeField] protected Text timerText;

    [SerializeField] protected int timer;

    [SerializeField] protected bool isRunning;

    protected override void Awake()
    {
        base.Awake();
        if (TimerPlay._instance != null)
        {
            Debug.LogWarning("Only TimerPlay allow to exists");
            return;
        }
        TimerPlay._instance = this;

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
        this.timer = 0;
        this.isRunning = true;
    }

    protected override void Start()
    {
        base.Start();
        this.CountTimer();
    }

    public virtual void CountTimer()
    {
        if (!this.isRunning) return;
        this.ResetTimer();
        StartCoroutine(this.Countdown());
    }

    private IEnumerator Countdown()
    {
        while (this.timer >= 0)
        {
            this.UpdateTimerText(this.timer);

            yield return new WaitForSeconds(1f);

            this.timer += 1;
        }
    }

    protected void UpdateTimerText(int currentTime)
    {
        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime - hours * 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime - hours * 3600 - minutes * 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00} : {1:00} : {2:00}", hours, minutes, seconds);
        }
    }

    public virtual void StopTimer()
    {
        isRunning = false;
        StopAllCoroutines();
    }
}
