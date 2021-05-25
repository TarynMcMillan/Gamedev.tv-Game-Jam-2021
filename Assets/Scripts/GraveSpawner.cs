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
    // string[] selectedColor = new string[] { "Red", "Blue", "Green", "Black", "Yellow", "Purple" };
    Treasure selectedItem;
    GameObject graveInstance;
    float numberofPiles = 0;

    private void Start()
    {
        GenerateGraves();
    }

    private void GenerateGraves()
    {
        for (int i = 0; i < dirtPiles.Length; i++)
        {
            graveInstance = Instantiate(gravePrefab, dirtPiles[i].transform.position, Quaternion.identity) as GameObject;
            graveInstance.transform.SetParent(dirtPiles[i].transform, false);
            //graveInstance.transform.parent = dirtPiles[i].transform;
            graveInstance.transform.localScale = new Vector3(1, 1, 1);
            float randomFactor = Random.Range(0, 100);
            if (randomFactor <= 30)
            {
                GameObject shimmerInstance = Instantiate(shimmerPrefab, graveInstance.transform.position, Quaternion.identity);
                //GameObject junkIDInstance = Instantiate(junkID);
                numberofPiles++;
                //junkIDInstance.transform.SetParent(graveInstance.transform, false);
            }
            GenerateItem();
        }
    }
    private void GenerateItem()
    {
        var randomFactor = Random.Range(0, item.Length);
        selectedItem = item[randomFactor];
        print(selectedItem);

        if (randomFactor == 0)
        {
            GameObject junkInstance = Instantiate(junkPrefab, graveInstance.transform.position, Quaternion.identity);
            junkInstance.transform.localScale = new Vector3(1, 1, 1);
            junkInstance.transform.SetParent(graveInstance.transform, false);
            //itemCopy = junkInstance;
            // graveInstance.GetComponentInChildren<ParticleSystem>().Play();
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
        return numberofPiles;
    }

    public float GetDirtPiles()
    {
        return dirtPiles.Length;
    }
}
/*


void AssignColor()
{
// var randomColorFactor = Random.Range(0, color.Length);
// var randomColor = color[randomColorFactor];
itemSprite.color = Color.red;
}
*/