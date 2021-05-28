using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] Light2D lantern;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float maxLanternIntensity = 1f;
    bool isLanternOn = false;
    void Start()
    {
        isLanternOn = true;
        print(isLanternOn);
      // todo make sure lantern turns on when player returns to splash screen after one round
      // todo make cursor into a shovel
    }

    // Update is called once per frame
    void Update()
    {
        if (isLanternOn)
        {
            while (lantern.intensity < maxLanternIntensity)
            {
                lantern.intensity += speed * Time.deltaTime;

            }
        }
        else
        {
            print("Lantern isn't working!");
        }
    }
}
