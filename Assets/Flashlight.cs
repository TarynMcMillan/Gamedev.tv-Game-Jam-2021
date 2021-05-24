using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseFlashLight()
    {
        StartCoroutine(TurnOnFlashLight());
        
    }

    IEnumerator TurnOnFlashLight()
    {
        ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Play();
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }

    }
}
