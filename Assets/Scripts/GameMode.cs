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

    [SerializeField]
    private TextMeshProUGUI m_arrowCountText;

    public int points = 0;

    [SerializeField]
    private FruitSpawner m_fruitSpawner;

    public int fruitTargetMaxIndex;
    public int fruitTargetIndex;

    private IEnumerator m_fruitSpawnLoop;

    [SerializeField]
    private float m_startTime = 20;

    private float m_currentTime = 0;

    private float m_nextTimeStamp = 0;

    [SerializeField]
    private GameObject m_lostPanel;

    [SerializeField]
    private GameObject m_mainPanel;

    private bool m_gameOver = false;

    public int ammoCount = 0;

    public AudioClip[] soundEffects;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_lostPanel.SetActive(false);

        SetTimerStart();

        //reset points to zero
        changePoints(0);

        m_fruitSpawnLoop = m_fruitSpawner.StartFruitSpawnLoop();
        StartCoroutine(m_fruitSpawnLoop);

        fruitTargetMaxIndex = m_fruitSpawner.m_FruitList.Count;

        audioSource = gameObject.GetComponent<AudioSource>();

        SetNextRandomFruit();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_gameOver)
        {
            UpdateTimer();
        }

        if (m_currentTime <= 0 || ammoCount <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            m_gameOver = true;
            m_lostPanel.SetActive(true);
            ammoCount = 0;
            StopCoroutine(m_fruitSpawnLoop);
        }
    }

    public void changePoints(int points)
    {
        this.points += points;

        if(this.points <= 0) this.points = 0;


        m_pointText.text = "Points: " + this.points.ToString();

        m_fruitSpawner.SpawnRandomFruit();

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
            ChangeAmmoCount(2);
            audioSource.clip = soundEffects[0];
            audioSource.Play();
        }
        else
        {
            changePoints(-50);
            audioSource.clip = soundEffects[1];
            audioSource.Play();


        }

        SetNextRandomFruit();
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

    public void ChangeAmmoCount(int ammoChange)
    {   
        ammoCount += ammoChange;

        if (ammoCount < 0) ammoCount = 0;

        m_arrowCountText.text = "Arrows: " + ammoCount.ToString();

  
    }


}
