using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject blockerPrefab;
    [SerializeField] GameObject fillerPrefab;
    GameObject blockerInstance = null;
    GameObject fillerInstance = null;
    float timeToSpawn = 2f;
    bool isEnemySpawned = false;

    private void Start()
    {
        // SpawnEnemy();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            isEnemySpawned = true;
        }
        if (isEnemySpawned && blockerInstance == null && fillerInstance == null)
        {
            SpawnEnemy();
        }
    }

   void SpawnEnemy()
    {
        blockerInstance = Instantiate(blockerPrefab, transform.position, Quaternion.identity);
        // enemyInstance.transform.parent = this.transform;
        blockerInstance.transform.SetParent(this.transform, false);
        fillerInstance = Instantiate(fillerPrefab, transform.position, Quaternion.identity);
        fillerInstance.transform.SetParent(this.transform, false);
    }
}
