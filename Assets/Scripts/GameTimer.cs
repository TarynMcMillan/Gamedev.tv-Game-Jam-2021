using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] float levelTime;
    public bool timerStopped = false;
    public bool timerPaused = false;
    public bool firstPress = false;
    float restartValue;

    private void Start()
    {
        
    }
    void Update()
    {
        if (timerStopped) { return; }
        else if (timerPaused && firstPress == false)
        {
            restartValue = GetComponent<Slider>().value;
            firstPress = true;
        }
        if (timerPaused == false && firstPress == true)
        {
            GetComponent<Slider>().value = restartValue / levelTime;
            firstPress = false;
            return;
        }
        
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            timerStopped = true;
            FindObjectOfType<LevelLoader>().StartLoseSequence();
        }
    }
}

