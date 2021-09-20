using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveSpawner : MonoBehaviour
{

    [SerializeField] Treasure[] item;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gravePrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject junkPrefab;
    [SerializeField] GameObject treasurePrefab;
    [SerializeField] GameObject shimmerPrefab;
    [SerializeField] GameObject junkID;
    [SerializeField] PileCounter pileCounter;
    GameObject[] quadrants;
    GameObject[] spawnPoints;
    Treasure selectedItem;
    GameObject graveInstance;
    float treasurePiles = 0f;
    float junkPiles = 0f;
    public int quadrantNumber = 3;
    public int maxQuadrant = 0;

    private void Awake()
    {
        quadrants = GameObject.FindGameObjectsWithTag("Quadrant");
        GenerateQuadrant();
    }

    public void GenerateQuadrant()
    {
        print("The quadrant number is " + quadrantNumber);
        treasurePiles = 0f;
        junkPiles = 0f;
        Transform[] children = quadrants[quadrantNumber].GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.GetComponent<SpawnPoint>())
            {
                GenerateGraves(child.gameObject);
            }
        }

        // pileCounter.GeneratePileCounter();
    }
    private void GenerateGraves(GameObject spawnPoint) // generate graves on dirt piles
    {
        graveInstance = Instantiate(gravePrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        graveInstance.transform.SetParent(spawnPoint.transform, false);
        //graveInstance.transform.parent = dirtPiles[i].transform;
        graveInstance.transform.localScale = new Vector3(1, 1, 1);
        GenerateItem();
    }
    private void GenerateItem() // generate item (either treasure or junk) for each grave
    {
        var randomFactor = Random.Range(0, item.Length);
        selectedItem = item[randomFactor];

        if (randomFactor == 0)
        {
            GameObject junkInstance = Instantiate(junkPrefab, graveInstance.transform.position, Quaternion.identity);
            junkInstance.transform.localScale = new Vector3(1, 1, 1); // do I need this?
            junkInstance.transform.SetParent(graveInstance.transform, false);

            GameObject shimmerInstance = Instantiate(shimmerPrefab, graveInstance.transform.position, Quaternion.identity);
            // print("There are " + junkPiles + " piles of junk in quadrant: " + quadrantNumber);
            junkPiles++;
        }
        else if (randomFactor == 1)
        {
            GameObject treasureInstance = Instantiate(treasurePrefab, graveInstance.transform.position, Quaternion.identity);
            treasureInstance.transform.localScale = new Vector3(1, 1, 1);
            treasureInstance.transform.SetParent(graveInstance.transform, false);

            // print("There are " + treasurePiles + " piles of treasure in quadrant: " + quadrantNumber);
            treasurePiles++;
        }
    }

    public float GetJunkPiles()
    {
        return junkPiles;
    }

    public float GetTreasurePiles()
    {
        return treasurePiles;
    }

}
    /*
    public Treasure GetItem()
    {
        return selectedItem;
    }

       pileCounter = pileCounter.GetComponent<PileCounter>();
       switch (quadrant)
       {
           case 0:
               dirtPiles = GameObject.FindGameObjectsWithTag("Grave");
               break;

           case 1:
               dirtPiles = GameObject.FindGameObjectsWithTag("Grave1");
               break;

           case 2:
               dirtPiles = GameObject.FindGameObjectsWithTag("Grave2");
               break;

           case 3:
               dirtPiles = GameObject.FindGameObjectsWithTag("Grave3");
               break;


    // print("There are this many spawn points: " + spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateGraves(spawnPoints[i]);
        }

       
    // print("There are " + treasurePiles + " treasure piles!");
    // print("There are " + junkPiles + " junk piles!");

    */
