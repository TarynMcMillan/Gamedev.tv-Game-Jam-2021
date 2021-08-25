using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FearManager : MonoBehaviour
{
    Slider slider;
    public float fearLevel = 0;
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
        if (fearLevel == maxFear && isMaxFear == false)
        {
            // print("fear condition");
            FindObjectOfType<LevelLoader>().StartLoseSequence();
            isMaxFear = true;
        }
    }

    public void IncreaseFear()
    {
        fearLevel++;
    }
}
