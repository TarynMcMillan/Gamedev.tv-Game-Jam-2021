using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject enemyInstance = null;
    float timeToSpawn = 2f;
    bool isEnemySpawned = false;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            isEnemySpawned = true;
        }
        if (isEnemySpawned && enemyInstance == null)
        {
            SpawnEnemy();
        }
    }

   void SpawnEnemy()
    {
        enemyInstance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        // enemyInstance.transform.parent = this.transform;
        enemyInstance.transform.SetParent(this.transform, false);
    }
}
