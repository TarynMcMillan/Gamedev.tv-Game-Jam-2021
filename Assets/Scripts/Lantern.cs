using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro; 

public class Lantern : MonoBehaviour
{
    [SerializeField] Light2D lanternLight;
    [SerializeField] AudioClip lanternSFX;
    [SerializeField] Button lanternButton;
    [SerializeField] TextMeshProUGUI lanternText;
    [SerializeField] float maxCharges = 3f;
    float chargesLeft;
    float cooldownTime = 1f;
    float nextFireTime = 0f;
    Animator lanternAnimator;
    public bool isLanternOn = false;
    bool isOnCooldown = false;
    float speed = 0.5f;
    ParticleSystem[] ps;
    void Start()
    {
        lanternAnimator = GetComponentInChildren<Animator>();
        chargesLeft = maxCharges - PlayerPrefsController.GetDifficulty();
        lanternText.text = "Charges Left: " + chargesLeft.ToString();
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
        if(nextFireTime == 0)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255, 116);
            //lanternAnimator.SetTrigger("cooldownReady");
        }
        if(chargesLeft <= 0)
        {
            lanternButton.interactable = false;
        }
    }
    void TurnOffLantern()
    {
        Cursor.visible = true;
        lanternAnimator.SetBool("isLit", false);
        isLanternOn = false;
        isOnCooldown = true;
        ps = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }

    }
    void PlaySFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = lanternSFX;
        audioSource.Play();
    }

    public void ResetCharges()
    {
        chargesLeft = maxCharges - PlayerPrefsController.GetDifficulty();
        lanternText.text = "Charges Left: " + chargesLeft.ToString();
        lanternButton.interactable = true;
    }

    public void UseLantern()
    {
        if (Time.time >= nextFireTime)
        {
            StartCoroutine(TurnOnLantern());
            nextFireTime = Time.time + cooldownTime;
            // Cursor.visible = false;
            chargesLeft--;
            lanternText.text = "Charges Left: " + chargesLeft.ToString();
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
        PlaySFX();
        ps = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Play();
        }
        yield return new WaitForSeconds(2f);
        TurnOffLantern();
    }
    public bool GettIsLanternOn()
    {
        return isLanternOn;
    }
}
