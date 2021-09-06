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
    public bool spawningBlocker = false;
    public bool spawningFiller = false;

    private void Start()
    {
        spawningBlocker = true;
        spawningFiller = true;
    }

    void Update()
    {
       
        if (spawningBlocker)
        {
            SpawnBlocker();
        }
        if (spawningFiller)
        {
            SpawnFiller();
        }

        /*
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            isEnemySpawned = true;
        }
        if (isEnemySpawned && blockerInstance == null && fillerInstance == null)
        {
            SpawnBlocker();
            SpawnFiller();
        }
        */
    }

    void SpawnBlocker()
    {
        // print("spawned a blocker");
        blockerInstance = Instantiate(blockerPrefab, transform.position, Quaternion.identity);
        // enemyInstance.transform.parent = this.transform;
        blockerInstance.transform.SetParent(this.transform, false);
        spawningBlocker = false;
    }

    void SpawnFiller()
    {
        // print("spawned a filler");
        fillerInstance = Instantiate(fillerPrefab, transform.position, Quaternion.identity);
        fillerInstance.transform.SetParent(this.transform, false);
        spawningFiller = false;
    }
}
