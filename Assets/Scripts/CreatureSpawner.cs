using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] GameObject creaturePrefab;
    [SerializeField] Transform creatureSpawnPoint;
    GameObject creatureInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateCreature()
    {
        creatureInstance = Instantiate(creaturePrefab, creatureSpawnPoint.position, Quaternion.identity);
        DontDestroyOnLoad(creatureInstance);
        // todo save the creatures so that when you exit scene and reload they are still there
;    }
}
