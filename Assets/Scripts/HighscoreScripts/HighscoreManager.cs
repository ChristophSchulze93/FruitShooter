using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField]
    public PlayerScores scoreList = new PlayerScores();

    [SerializeField]
    private GameObject scoreBoardPanel;

    [SerializeField]
    private GameObject scoreBoardEntryPanel;


    private void Start()
    {
        scoreList = SaveScores.LoadFromJson();
        scoreList.scores.Sort(SortByScore);
        CreateScoreEntries();
    }

    public void CreateScoreEntries()
    {
        foreach(ScoreItem item in scoreList.scores)
        {
            GameObject temp = Instantiate(scoreBoardEntryPanel, scoreBoardPanel.transform);         
        }
    }

   public static int SortByScore(ScoreItem item1, ScoreItem item2)
    {
        return item1.score.CompareTo(item2.score);
    }
}
