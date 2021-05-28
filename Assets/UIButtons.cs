using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject dirtPile;
    [SerializeField] AudioClip shovelSFX;
    Animator graveAnimator;
    AudioSource audioSource;

    private void Start()
    {
        graveAnimator = GetComponentInChildren<Animator>();
    }
    public void LoadGame()
    {
       
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shovelSFX;
        StartCoroutine(DigGrave());
        
    }

    IEnumerator DigGrave()
    {
        graveAnimator.SetTrigger("dig grave");
        float clipLength = shovelSFX.length;
        audioSource.Play();
        yield return new WaitForSeconds(clipLength);
        TriggerFade();
    }

    void TriggerFade()
    {
        print("fading the scene");
    }    
}
