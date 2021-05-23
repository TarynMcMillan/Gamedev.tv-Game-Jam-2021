using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveSpawner : MonoBehaviour
{
    
    [SerializeField] Treasure[] item;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gravePrefab;
    string[] selectedColor = new string[] { "Red", "Blue", "Green", "Black", "Yellow", "Purple" };
    PointsManager pointsManager;
    Treasure selectedItem;
    Animator graveAnimator;
    GameObject[] graves;
 

    private void Start()
    {
        pointsManager = slider.GetComponent<PointsManager>();
        // GenerateGraves();
    }
    

    private void GenerateGraves()
    {
        foreach (GameObject grave in graves)
            {
            GameObject graveInstance = Instantiate(gravePrefab, transform.position, Quaternion.identity);
            GenerateItem();
        }
    }
    private void GenerateItem()
    {
        var randomFactor = Random.Range(0, item.Length);
        // AssignColor();
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