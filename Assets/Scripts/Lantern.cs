using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{
    float cooldownTime = 10f;
    float nextFireTime = 0f;
    Animator lanternAnimator;
    void Start()
    {
        lanternAnimator = GetComponentInChildren<Animator>();
        Button a = GetComponent<Button>();
        a.onClick.AddListener(delegate () { UseLantern(); });
    }

    void Update()
    {
        
    }
    public void UseLantern()
    {
        if (Time.time >= nextFireTime)
        {

            StartCoroutine(TurnOnLantern());
            nextFireTime = Time.time + cooldownTime;
        }
        else
        {
            print("This ability is still on cooldown.");
        }
        
    }

    IEnumerator TurnOnLantern()
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
