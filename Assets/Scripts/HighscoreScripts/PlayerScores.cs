using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerScores
{
    public List<ScoreItem> scores = new List<ScoreItem>();
}

[System.Serializable]
public class ScoreItem
{
    public string playerName;
    public int score;

    public ScoreItem(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
