using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HighscoreScene()
    {
        SceneManager.LoadScene(2);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void CopyToClipboardButton()
    {
        GUIUtility.systemCopyBuffer = Application.persistentDataPath;
    }
}
