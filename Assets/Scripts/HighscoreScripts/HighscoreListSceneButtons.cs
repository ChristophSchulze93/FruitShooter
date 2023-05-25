using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreListSceneButtons : MonoBehaviour
{
    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
