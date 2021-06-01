using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] float levelTime;
    public bool timerStopped = false;

    // Update is called once per frame
    void Update()
    {
        if (timerStopped) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            // TODO trigger Timer Finished sequence
            //FindObjectOfType<LevelController>().LevelTimerFinished();
            timerStopped = true;
        }
    }
}

