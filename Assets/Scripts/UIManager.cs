using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_inputFieldText;

    public void RestartScene()
    {
        LoadHighscoresAndSaveBest();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadHighscoreScene()
    {
        LoadHighscoresAndSaveBest();
        SceneManager.LoadScene(2);
    }

    public void LoadHighscoresAndSaveBest()
    {
        PlayerScores playerScores = SaveScores.LoadFromJson();

        if(playerScores == null )
        {
            playerScores = new PlayerScores();
        }

        if (m_inputFieldText.text.Length == 1) return;
        print(m_inputFieldText.text.Length);

        playerScores.scores.Add(new ScoreItem(m_inputFieldText.text, GameMode.Instance.points));

        playerScores.scores.Sort(SaveScores.SortByScore);
        playerScores.scores = ShortenListen(playerScores.scores, 5);

        SaveScores.SaveToJson(playerScores);
    }

    public List<T> ShortenListen<T>(List<T> list, int listMaxIndex)
    {
        List<T> result = new List<T>();

        for(int i = 0; i < list.Count && i <listMaxIndex; i++)
        {
            result.Add(list[i]);
        }

        return result;
    }
}
