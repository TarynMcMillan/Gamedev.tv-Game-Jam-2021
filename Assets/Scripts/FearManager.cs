using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FearManager : MonoBehaviour
{
    Slider slider;
    public float fearLevel = 0;
    public float maxFear = 50f;
    bool isMaxFear = false;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxFear;
    }
    void Update()
    {
        print("Is show skull? " + IsShowSkull());
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

    public bool IsShowSkull()
    {
        if (fearLevel <= maxFear)
        {
            return true;
        }
        return false;
    }
}
