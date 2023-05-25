using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardEntry : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_playerNameText;
    [SerializeField]
    private TextMeshProUGUI m_playerScoreText;

    public void InitEntry(string playerName, int score)
    {
        m_playerNameText.text = playerName;
        m_playerScoreText.text = score.ToString();
    }

}
