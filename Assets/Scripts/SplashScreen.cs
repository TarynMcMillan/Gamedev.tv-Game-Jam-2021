using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] Light2D lantern;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float maxLanternIntensity = 4f;
    [SerializeField] GameObject fadeCanvas;
    [SerializeField] AudioClip UISFX;
    bool isLanternOn = false;
    Animator transition;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isLanternOn = true;
        print(isLanternOn);
        transition = fadeCanvas.GetComponent<Animator>();
    }
    void Update()
    {
        if (isLanternOn)
        {
            if (lantern.intensity < maxLanternIntensity)
            {
                lantern.intensity += speed * Time.deltaTime;
            }
            else if (lantern.intensity >= maxLanternIntensity)
            {
                lantern.intensity = maxLanternIntensity;
            }
        }
        else
        {
            print("Lantern isn't working!");
        }
    }

    public void LoadGame()
    {
        Time.timeScale = 1;
        // PlayUISFX();
        StartCoroutine(FadeScene());
        SceneManager.LoadScene("Graveyard");
    }
    public void LoadOptions()
    {
        
        StartCoroutine(FadeScene());
        SceneManager.LoadScene("Options");
    }
    IEnumerator FadeScene()
    {
        // PlayUISFX();
        transition.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
    }

    public void PlayUISFX()
    {
        audioSource.PlayOneShot(UISFX, 1f);
    }

}
