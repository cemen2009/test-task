using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    private Transform[] _spawnPoints = new Transform[3];

    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject enemyPrefab;

    private float spawnTime;
    private const float minSpawnTime = 3f;

    private int[] enemiesCount = new int[2];

    private void Awake()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        spawnTime = 9f;

        // 1 boss; 4 default enemies
        enemiesCount[0] = 1;
        enemiesCount[1] = 4;
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());   
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            if (spawnTime == minSpawnTime)
            {
                // boss enemy spawn (one time)
                for (int i = 0; i < enemiesCount[0]; i++)
                {
                    GameObject enemy = Instantiate(bossPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
                }

                // default enemies spawn (4 time)
                for (int i = 0; i < enemiesCount[1]; i++)
                {
                    GameObject enemy = Instantiate(enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
                }
            }
            else
            {
                // boss enemies spawn
                for (int i = 0; i < enemiesCount[0]; i++)
                {
                    GameObject enemy = Instantiate(bossPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
                }

                // default enemies spawn
                for (int i = 0; i < enemiesCount[1]; i++)
                {
                    GameObject enemy = Instantiate(enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
                }

                // +1 boss; +2 default enemies
                enemiesCount[0]++;
                enemiesCount[1]++;
            }
            yield return new WaitForSecondsRealtime(spawnTime);

            spawnTime = spawnTime > minSpawnTime ? spawnTime - 0.2f : minSpawnTime;
        }
    }
}
