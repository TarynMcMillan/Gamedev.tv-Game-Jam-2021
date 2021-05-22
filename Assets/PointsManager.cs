using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointsManager : MonoBehaviour
{
    [SerializeField] float maxNumber;
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
        
    }

    public void CalculatePoints(Treasure item)
    {
        numberOfPoints = item.GetPoints();
        print("The number of points is " + numberOfPoints);
        slider.value += numberOfPoints;
    }
}
