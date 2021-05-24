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
    // string[] selectedColor = new string[] { "Red", "Blue", "Green", "Black", "Yellow", "Purple" };
    PointsManager pointsManager;
    Treasure selectedItem;
    Animator graveAnimator;
    GameObject graveInstance;
    bool isJunk;
    public static GameObject itemCopy;

    private void Start()
    {
        pointsManager = slider.GetComponent<PointsManager>();
        GenerateGraves();
        print(selectedItem);
    }
    

    private void GenerateGraves()
    {
        for(int i =0; i<dirtPiles.Length; i++)
            {
            graveInstance = Instantiate(gravePrefab, dirtPiles[i].transform.position, Quaternion.identity) as GameObject;
            graveInstance.transform.SetParent(dirtPiles[i].transform, false);
            //graveInstance.transform.parent = dirtPiles[i].transform;
            graveInstance.transform.localScale = new Vector3(1, 1, 1);
            GenerateItem();
        }
    }
    private void GenerateItem()
    {
        var randomFactor = Random.Range(0, item.Length);
        selectedItem = item[randomFactor];
        print(selectedItem);
        if(randomFactor == 0)
        {
            isJunk = true;
            GameObject junkInstance = Instantiate(junkPrefab, graveInstance.transform.position, Quaternion.identity);
            junkInstance.transform.localScale = new Vector3(1, 1, 1);
            junkInstance.transform.SetParent(graveInstance.transform, false);
            //itemCopy = junkInstance;
            // graveInstance.GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (randomFactor == 1)
        {
            isJunk = false;
            GameObject treasureInstance = Instantiate(treasurePrefab, graveInstance.transform.position, Quaternion.identity);
            treasureInstance.transform.localScale = new Vector3(1, 1, 1);
            treasureInstance.transform.SetParent(graveInstance.transform, false);
            //itemCopy = treasureInstance;
        }
    }

    public Treasure GetItem()
    {
        return selectedItem;
    }

    public GameObject GetItemCopy()
    {
        return itemCopy;
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