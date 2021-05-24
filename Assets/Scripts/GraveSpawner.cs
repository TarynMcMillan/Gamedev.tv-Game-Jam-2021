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

    // string[] selectedColor = new string[] { "Red", "Blue", "Green", "Black", "Yellow", "Purple" };
    PointsManager pointsManager;
    Treasure selectedItem;
    Animator graveAnimator;
   

    private void Start()
    {
        pointsManager = slider.GetComponent<PointsManager>();
        GenerateGraves();
    }
    

    private void GenerateGraves()
    {
        for(int i =0; i<dirtPiles.Length; i++)
            {
            GameObject graveInstance = Instantiate(gravePrefab, dirtPiles[i].transform.position, Quaternion.identity) as GameObject;
            graveInstance.transform.parent = dirtPiles[i].transform;
            graveInstance.transform.localScale = new Vector3(1, 1, 1);
            // GenerateItem();
        }
    }
    private void GenerateItem()
    {
        var randomFactor = Random.Range(0, item.Length);
        selectedItem = item[randomFactor];
        SpriteRenderer itemSprite = selectedItem.GetSprite();
        pointsManager.CalculatePoints(selectedItem);
        
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