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
        if (scoreList == null) return;
        scoreList.scores.Sort(SaveScores.SortByScore);
        CreateScoreEntries();
    }

    public void CreateScoreEntries()
    {
        foreach(ScoreItem item in scoreList.scores)
        {
            GameObject temp = Instantiate(scoreBoardEntryPanel, scoreBoardPanel.transform);
            temp.GetComponent<ScoreBoardEntry>().InitEntry(item.playerName, item.score);           
        }
    }


}
