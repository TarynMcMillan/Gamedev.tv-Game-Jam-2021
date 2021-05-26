using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class Lantern : MonoBehaviour
{
    [SerializeField] Light2D lanternLight;
    float cooldownTime = 1f;
    float nextFireTime = 0f;
    Animator lanternAnimator;
    bool isLanternOn;
    float speed = 0.5f;
    void Start()
    {
        lanternAnimator = GetComponentInChildren<Animator>();
        // Button a = GetComponent<Button>();
        // a.onClick.AddListener(delegate () { UseLantern(); });
    }

    void Update()
    {
        if (isLanternOn)
        {
            lanternLight.gameObject.SetActive(true);
            lanternLight.intensity += speed * Time.deltaTime;
        }
        else
        {
            lanternLight.gameObject.SetActive(false);
        }
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
        lanternAnimator.SetBool("isLit", true);
        isLanternOn = true;
        ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Play();
        }
        yield return new WaitForSeconds(2f);
        lanternAnimator.SetBool("isLit", false);
        isLanternOn = false;
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }

    }

    public bool GettIsLanternOn()
    {
        return isLanternOn;
    }
}
