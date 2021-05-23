using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseStateManager : MonoBehaviour
{
    [SerializeField] GameObject creaturePrefab;
    private void Start()
    {
        print(CreatureSpawner.creatures.Count);

        for (int i = 0; i < CreatureSpawner.creatures.Count; i++)
        {
            print("I am a creature");
            Instantiate(creaturePrefab, transform.position, Quaternion.identity);
           
        }
    }


}
/*
//Instantiate(CreatureSpawner.creatures[i], transform.position, Quaternion.identity);    

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