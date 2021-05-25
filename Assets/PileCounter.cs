using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileCounter : MonoBehaviour
{
    float junkPiles;
    float treasurePiles;
    // Start is called before the first frame update
    void Start()
    {
        junkPiles = FindObjectOfType<GraveSpawner>().GetNumberofPiles();
        print("There are " + junkPiles + "piles of Junk.");
        treasurePiles = FindObjectOfType<GraveSpawner>().GetDirtPiles();
        print("There are " + treasurePiles + "piles of Treasure.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
