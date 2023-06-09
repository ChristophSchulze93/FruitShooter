using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> m_FruitList;

    private bool m_GameRunning = true;

    public Transform spawnPosition;

    [SerializeField]
    private int m_spawnWaitingTime = 2;

    [SerializeField]
    private int m_SpawnRange = 20;

    public int spawnSearchedFruitInterval = 2;

    private int m_currentSearchedFruitIntervalCounter = 2;

    public bool variantB = false;

    private void Start()
    {
        variantB = FindObjectOfType<VariantManager>().variantB;

        foreach(GameObject fruit in  m_FruitList)
        {
            fruit.GetComponent<FruitScript>().fastFalling = variantB;
        }
    }

    public void SpawnRandomFruit()
    {
        float randomXPosition = Random.Range(spawnPosition.position.x - m_SpawnRange, spawnPosition.position.x + m_SpawnRange);
        Instantiate(PickRandomFruitFromList(m_FruitList), new Vector3(randomXPosition, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity);
    }

    public IEnumerator StartFruitSpawnLoop()
    {
        while (m_GameRunning)
        {
            yield return SpawnFruit();
        }
    }

    private GameObject PickRandomFruitFromList(List<GameObject> fruitList)
    {
        return fruitList[Random.Range(0, fruitList.Count)];
    }


    public IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(m_spawnWaitingTime);
        float randomXPosition = Random.Range(spawnPosition.position.x - m_SpawnRange, spawnPosition.position.x + m_SpawnRange);



        if (spawnSearchedFruitInterval == m_currentSearchedFruitIntervalCounter)
        {
            Instantiate(m_FruitList[GameMode.Instance.fruitTargetIndex], new Vector3(randomXPosition, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity);
            m_currentSearchedFruitIntervalCounter = 0;
        }
        else
        {
            Instantiate(PickRandomFruitFromList(m_FruitList), new Vector3(randomXPosition, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity);

        }

        m_currentSearchedFruitIntervalCounter++;
    }




}
