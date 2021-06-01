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
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxFear;
    }
    void Update()
    {
        slider.value = fearLevel;
        if (fearLevel == maxFear)
        {
            isMaxFear = true;
            FindObjectOfType<LevelLoader>().StartLoseSequence();
        }
    }

    public void IncreaseFear()
    {
        fearLevel++;
    }
}
