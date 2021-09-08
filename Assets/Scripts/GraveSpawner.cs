using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveSpawner : MonoBehaviour
{

    [SerializeField] Treasure[] item;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gravePrefab;
    [SerializeField] GameObject[] dirtPiles;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject junkPrefab;
    [SerializeField] GameObject treasurePrefab;
    [SerializeField] GameObject shimmerPrefab;
    [SerializeField] GameObject junkID;
    [SerializeField] PileCounter pileCounter;
    [SerializeField] int quadrant;
    Treasure selectedItem;
    GameObject graveInstance;
    float numberOfPiles = 0;

    private void Start()
    {
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

        }
        dirtPiles = GameObject.FindGameObjectsWithTag("Grave");
        print("There are this many dirt piles: " + dirtPiles.Length);
        GenerateGraves();
    }

    private void GenerateGraves() // generate graves on dirt piles
    {
        for (int i = 0; i < dirtPiles.Length; i++)
        {
            graveInstance = Instantiate(gravePrefab, dirtPiles[i].transform.position, Quaternion.identity) as GameObject;
            graveInstance.transform.SetParent(dirtPiles[i].transform, false);
            //graveInstance.transform.parent = dirtPiles[i].transform;
            graveInstance.transform.localScale = new Vector3(1, 1, 1);
            GenerateItem();
        }
    }
    private void GenerateItem() // generate item (either treasure or junk) for each grave
    {
        // TODO make sure the prefab dots aren't visible
        var randomFactor = Random.Range(0, item.Length);
        selectedItem = item[randomFactor];
        // print(selectedItem);

        if (randomFactor == 0)
        {
            GameObject junkInstance = Instantiate(junkPrefab, graveInstance.transform.position, Quaternion.identity);
            junkInstance.transform.localScale = new Vector3(1, 1, 1); // do I need this?
            junkInstance.transform.SetParent(graveInstance.transform, false);
            
            GameObject shimmerInstance = Instantiate(shimmerPrefab, graveInstance.transform.position, Quaternion.identity);
                
            numberOfPiles++;
            pileCounter.GeneratePileCounter(numberOfPiles);     
        }
        else if (randomFactor == 1)
        {
            GameObject treasureInstance = Instantiate(treasurePrefab, graveInstance.transform.position, Quaternion.identity);
            treasureInstance.transform.localScale = new Vector3(1, 1, 1);
            treasureInstance.transform.SetParent(graveInstance.transform, false);
        }
    }

    public Treasure GetItem()
    {
        return selectedItem;
    }

    public float GetNumberofPiles()
    {
        return numberOfPiles;
    }

    public float GetDirtPiles()
    {
        return dirtPiles.Length;
    }
}
