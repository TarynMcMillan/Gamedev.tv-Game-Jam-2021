using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PointsManager : MonoBehaviour
{
    [SerializeField] float maxNumber;
    // [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] GameObject sliderHandle;
    [SerializeField] GameObject pointsPrefab;
    [SerializeField] float junkPoints;
    [SerializeField] float treasurePoints;
    Slider slider;
    float numberOfPoints;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxNumber;
        slider.value = 0;
    }

    void Update()
    {
        // pointsText.transform.position = sliderHandle.transform.position;
    }

    public void CalculatePoints(string item)
    {
        if (item == "Junk")
        {
            numberOfPoints = junkPoints;
        }
        else if (item == "Treasure")
        {
            numberOfPoints = treasurePoints;
        }
        // numberOfPoints = item.GetPoints();
        // print("The number of points is " + numberOfPoints);
        slider.value += numberOfPoints;
        // PrintPoints();
    }

    void PrintPoints()
    {
        GameObject pointsInstance = Instantiate(pointsPrefab, sliderHandle.transform.position, Quaternion.identity);
        // pointsInstance.transform.parent = slider.transform.parent;
        pointsInstance.GetComponent<TextMeshProUGUI>().text = numberOfPoints.ToString();
        // pointsText.text = numberOfPoints.ToString();
        // todo make this into an instanatiated prefab
        // todo add SFX
        // todo make into a coroutine? and destroy clone after set amount of time so no clutter in Hierarchy
    }
}
