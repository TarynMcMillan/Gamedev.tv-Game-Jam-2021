using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grave : MonoBehaviour
{
    [SerializeField] AudioClip shovelSFX;
    [SerializeField] AudioClip skullSFX;
    [SerializeField] GameObject junkPrefab;
    [SerializeField] GameObject treasurePrefab;
    PileCounter pileCounter;
    Animator graveAnimator;
    AudioSource audioSource;
    string revealedItem = null;
    public bool isEmpty = false;

    void Start()
    {
        pileCounter = FindObjectOfType<PileCounter>();
        audioSource = GetComponent<AudioSource>();
        graveAnimator = GetComponentInChildren<Animator>();
        Button b = GetComponent<Button>();
        b.onClick.AddListener(delegate () { DigGrave(); });
    }

    public void DigGrave()
    {
            if (isEmpty == false)
            {
                PlayAnimation();
                RevealItem();
                PlaySFX();
            }
            else
            {
                print("This grave is empty.");
            }
    }

    private void PlaySFX()
    {
        audioSource.clip = shovelSFX;
        audioSource.Play();
    }

    private void RevealItem()
    {
        // print("calling Reveal Item");
        if (gameObject.transform.Find("Junk(Clone)")!= null)
        {
            FindObjectOfType<FearManager>().IncreaseFear();
            revealedItem = "Junk";
            float fearStatus = FindObjectOfType<FearManager>().fearLevel;
            if (fearStatus <=2)
            {
                audioSource.PlayOneShot(skullSFX, 1f);
                // todo check if fear is maxed out before spawning the instance
                GameObject junkInstance = Instantiate(junkPrefab, this.transform.position, Quaternion.identity);
                Destroy(junkInstance, 1f);
                // test
            }
            
        }
        else
        {
            // print("found treasure");
            pileCounter.FindTreasure();
            revealedItem = "Treasure";
        }
        isEmpty = true;
    }

    private void PlayAnimation()
    {
        graveAnimator.SetTrigger("dig grave");
    }

}