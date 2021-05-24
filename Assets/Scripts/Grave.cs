using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grave : MonoBehaviour
{
    [SerializeField] AudioClip shovelSFX;
    // [SerializeField] GraveSpawner graveSpawner;
    // [SerializeField] PointsManager pointsManager;
    Animator graveAnimator;
    [SerializeField] GameObject junkPrefab;
    [SerializeField] GameObject treasurePrefab;

    void Start()
    {
        graveAnimator = GetComponentInChildren<Animator>();
        Button b = GetComponent<Button>();
        b.onClick.AddListener(delegate () { DigGrave(); });
    }

    public void DigGrave()
    {
        PlayAnimation();
        RevealItem();
        PlaySFX();
    }

    private void PlaySFX()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = shovelSFX;
        audio.Play();
    }

    private void RevealItem()
    {
        if (gameObject.transform.Find("Junk(Clone)")!= null)
        {
            print("this is junk");
            GameObject junkInstance = Instantiate(junkPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            print("this is treasure");
            GameObject treasureInstance = Instantiate(treasurePrefab, transform.position, Quaternion.identity);
        }
        /*
        //GetComponentInChildren<ItemSpawner>();
        var foundItem = GetComponentInParent<GraveSpawner>().GetItemCopy();
        print(foundItem.transform.position);
        print("The found item is " + foundItem);
        //SpriteRenderer itemSprite = foundItem.GetSprite();
        // pointsManager.CalculatePoints(foundItem);
        */

    }

    private void PlayAnimation()
    {
        graveAnimator.SetTrigger("dig grave");
    }

}
