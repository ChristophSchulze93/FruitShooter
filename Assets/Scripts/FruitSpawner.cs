using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_FruitList;

    private bool m_GameRunning = true;

    public Transform spawnPosition;

    [SerializeField]
    private int m_SpawnRange = 20;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
    }

    private IEnumerator SpawnRandomFruit()
    {

        yield return new WaitForSeconds(3);
        float randomXPosition = Random.Range(spawnPosition.position.x - m_SpawnRange, spawnPosition.position.x + m_SpawnRange);
        Instantiate(PickRandomFruitFromList(m_FruitList), new Vector3(randomXPosition, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity);
        print("spawned fruit");
    }

    private IEnumerator StartGame()
    {
        while (m_GameRunning)
        {
            print("game loop");
            yield return SpawnRandomFruit();
        }
    }

    private GameObject PickRandomFruitFromList(List<GameObject> fruitList)
    {
        return fruitList[Random.Range(0, fruitList.Count)];
    }


}
