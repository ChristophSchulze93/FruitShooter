using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameMetrics : MonoBehaviour
{
    public static bool usingVariantB = true;
    public static int shots;
    public static int correctHits;
    public static int wrongHits;
    public static int score;
    public static float playTime;

    public static Metrics metrics;

    private void Start()
    {
        ResetMetrics();
        metrics = LoadFromJson();
        //metrics.metric.Add(new MetricItem(usingKeyboard, shots, correctHits, wrongHits,score));


        //SaveToJson(metrics);
    }

    public static Metrics LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/Metrics.json";
        print(filePath);

        if (!File.Exists(filePath)) return new Metrics();

        string metricData = File.ReadAllText(filePath);

        print(metricData);

        Metrics metricList = JsonUtility.FromJson<Metrics>(metricData);


        return metricList;

    }

    public static void SaveToJson(Metrics metricsList)
    {
        string filePath = Application.persistentDataPath + "/Metrics.json";
        string metricData = JsonUtility.ToJson(metricsList);

        File.WriteAllText(filePath, metricData);
        print("saved");
    }

    public static void SaveMetrics()
    {
        metrics.metric.Add(new MetricItem(VariantManager.Instance.variantB, shots, correctHits, wrongHits,score, playTime));


        SaveToJson(metrics);
    }

    private void ResetMetrics()
    {
        shots = 0;
        correctHits = 0;
        wrongHits = 0;
        score = 0;
        playTime = 0;
}


}
