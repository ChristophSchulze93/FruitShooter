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
    private int m_spawnWaitingTime = 3;

    [SerializeField]
    private int m_SpawnRange = 20;

    private IEnumerator SpawnRandomFruit()
    {
        yield return new WaitForSeconds(m_spawnWaitingTime);
        float randomXPosition = Random.Range(spawnPosition.position.x - m_SpawnRange, spawnPosition.position.x + m_SpawnRange);
        Instantiate(PickRandomFruitFromList(m_FruitList), new Vector3(randomXPosition, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity);
    }

    public IEnumerator StartFruitSpawnLoop()
    {
        while (m_GameRunning)
        {
            yield return SpawnRandomFruit();
        }
    }

    private GameObject PickRandomFruitFromList(List<GameObject> fruitList)
    {
        return fruitList[Random.Range(0, fruitList.Count)];
    }


}
