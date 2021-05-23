using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseStateManager : MonoBehaviour
{
    private void Start()
    {

        for (int i = 0; i < CreatureSpawner.creatures.Count; i++)
        {
            print(CreatureSpawner.creatures.Count);
            Instantiate(CreatureSpawner.creatures[1], transform.position, Quaternion.identity);
        }
    }


}
  /*
    public static HouseStateManager Instance
    {
        get;
        set;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Instance = this;
    }

    void Start()
    {
        //Load first game scene (probably main menu)?
    
    }

    // Data persisted between scenes
    public int exp = 0;
    public int armor = 0;
    public int weapon = 0;
    //...
}

    */