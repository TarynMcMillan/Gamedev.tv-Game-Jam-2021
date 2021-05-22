using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PointsManager : MonoBehaviour
{
    [SerializeField] float maxNumber;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] GameObject sliderHandle;
    Slider slider;
    float numberOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxNumber;
        slider.value = maxNumber/2;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.transform.position = sliderHandle.transform.position;
    }

    public void CalculatePoints(Treasure item)
    {
        numberOfPoints = item.GetPoints();
        print("The number of points is " + numberOfPoints);
        slider.value += numberOfPoints;
        PrintPoints();
    }

    void PrintPoints()
    {
        pointsText.text = numberOfPoints.ToString();
        // todo make this into an instanatiated prefab
        // todo add SFX
    }
}
