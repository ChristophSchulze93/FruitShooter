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
    public bool usingVariantB;
    public int shots;
    public int correctHits;
    public int wrongHits;
    public int score;
    public float playTime;

    public MetricItem(bool usingVariantB, int shots, int correctHits, int wrongHits, int score, float playTime)
    {
        this.usingVariantB = usingVariantB;
        this.shots = shots;
        this.correctHits = correctHits; 
        this.wrongHits = wrongHits; 
        this.score = score;
        this.playTime = playTime;
    }
}

