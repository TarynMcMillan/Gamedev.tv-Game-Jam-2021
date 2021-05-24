using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Seance : MonoBehaviour
{
    [SerializeField] Light2D sceneLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSeance()
    {
        sceneLight.intensity = 0;
    }
}
