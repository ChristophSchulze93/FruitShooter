using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    //Singelton Instance
    public static GameMode Instance;

    [SerializeField]
    private TextMeshProUGUI m_pointText;

    [SerializeField]
    private TextMeshProUGUI m_fruitTargetText;

    [SerializeField]
    private TextMeshProUGUI m_TimeText;

    private int points = 0;

    [SerializeField]
    private FruitSpawner m_fruitSpawner;

    public int fruitTargetMaxIndex;
    public int fruitTargetIndex;

    private IEnumerator m_fruitSpawnLoop;

    [SerializeField]
    private float m_startTime = 20;

    private float m_currentTime = 0;

    private float m_nextTimeStamp = 0;

    //private float m_updateCurrentTimeInterval = 0f;



    // Start is called before the first frame update
    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }



        SetTimerStart();

        //reset points to zero
        changePoints(0);

        m_fruitSpawnLoop = m_fruitSpawner.StartFruitSpawnLoop();
        StartCoroutine(m_fruitSpawnLoop);

        fruitTargetMaxIndex = m_fruitSpawner.m_FruitList.Count;

        SetNextRandomFruit();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        if (m_currentTime < 0)
        {

        }
    }

    public void changePoints(int points)
    {
        this.points += points;

        if(this.points <= 0)
        {
            this.points = 0;
        }

        m_pointText.text = "Points: " + points.ToString();

        SetNextRandomFruit();
    }

    public void SetNextRandomFruit()
    {
        fruitTargetIndex = Random.Range(0, fruitTargetMaxIndex);
        m_fruitTargetText.text = ((FruitScript.FruitType)fruitTargetIndex).ToString();
    }

    public void HitFruit(int fruitIndex)
    {
        if(fruitIndex == fruitTargetIndex)
        {
            changePoints(50);
        }
        else
        {
            changePoints(-50);
        }      
    }

    private void UpdateTimer()
    {
        m_currentTime -= Time.deltaTime;
        //m_TimeText.text = "Time: " + (int)m_currentTime;

        if (m_currentTime <= m_nextTimeStamp)
        {
            m_nextTimeStamp = m_currentTime - 1;
            m_TimeText.text = "Time: " + (int)m_currentTime;
        }
    }

    private void SetTimerStart()
    {
        m_currentTime = m_startTime;
        m_nextTimeStamp = m_currentTime - 1;

        m_TimeText.text = "Time: " + m_startTime;
    }
}