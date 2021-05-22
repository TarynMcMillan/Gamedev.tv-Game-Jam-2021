using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] Light2D lantern;
    [SerializeField] float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        lantern.intensity += speed * Time.deltaTime;
    }
}
