using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASyncManager : TunBehaviour
{
    [Header("ASyncManager")]

    private static ASyncManager _instance;

    public static ASyncManager Instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        if (ASyncManager._instance != null)
        {
            Debug.LogWarning("Only ASyncManager allow to exists");
            return;
        }
        ASyncManager._instance = this;
    }

    public virtual void LoadASync(Slider slider, string sceneName)
    {
        StopCoroutine(this.LoadSceneByName(slider, sceneName));
        StartCoroutine(this.LoadSceneByName(slider, sceneName));
    }

    IEnumerator LoadSceneByName(Slider slider, string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }
}
