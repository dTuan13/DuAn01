using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : BaseBtn
{
    protected override void OnClick()
    {
        this.ReloadCurrentScene();
    }

    public void ReloadCurrentScene()
    {
        GameOverManager.Instance.ShowGameOverManager(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
