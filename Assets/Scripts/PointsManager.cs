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
    Slider slider;
    float numberOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxNumber;
        slider.value = maxNumber;
    }

    // Update is called once per frame
    void Update()
    {
        // pointsText.transform.position = sliderHandle.transform.position;
    }

    public void CalculatePoints(Treasure item)
    {
        numberOfPoints = item.GetPoints();
        print("The number of points is " + numberOfPoints);
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
