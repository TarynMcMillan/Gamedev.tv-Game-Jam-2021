using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    float cooldownTime = 10f;
    float nextFireTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UseFlashLight();
                nextFireTime = Time.time + cooldownTime;
            }
        }
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
