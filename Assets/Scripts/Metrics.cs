using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Metrics 
{
    public List<MetricItem> metric = new List<MetricItem>();
}

[System.Serializable]
public class MetricItem
{
    public bool usingKeyboard;
    public int shots;
    public int correctHits;
    public int wrongHits;
    public int score;

    public MetricItem(bool usingKeyboard, int shots, int correctHits, int wrongHits, int score)
    {
        this.usingKeyboard = usingKeyboard;
        this.shots = shots;
        this.correctHits = correctHits; 
        this.wrongHits = wrongHits; 
        this.score = score;
    }
}

