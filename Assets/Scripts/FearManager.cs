using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FearManager : MonoBehaviour
{
    Slider slider;
    float fearLevel = 0;
    float maxFear = 3;
    bool isMaxFear = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxFear;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = fearLevel;
        if (fearLevel == maxFear)
        {
            isMaxFear = true;
        }
    }

    public void IncreaseFear()
    {
        fearLevel++;
    }
}
