using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScores : MonoBehaviour
{

    public static PlayerScores LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/ScoreTable.json";
        
        if (!File.Exists(filePath)) return new PlayerScores();

        string scoreData = File.ReadAllText(filePath);

        PlayerScores scoreList = JsonUtility.FromJson<PlayerScores>(scoreData);

        //print(scoreData);

        return scoreList;

    }

    public static void SaveToJson(PlayerScores scoreList)
    {
        string filePath = Application.persistentDataPath + "/ScoreTable.json";
        string scoreData = JsonUtility.ToJson(scoreList);

        File.WriteAllText(filePath, scoreData);
        print("saved");
    }

    public static int SortByScore(ScoreItem item1, ScoreItem item2)
    {
        return item2.score.CompareTo(item1.score);
    }
}
