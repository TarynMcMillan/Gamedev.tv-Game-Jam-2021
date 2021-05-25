using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grave : MonoBehaviour
{
    [SerializeField] AudioClip shovelSFX;
    [SerializeField] GameObject junkPrefab;
    [SerializeField] GameObject treasurePrefab;
    Animator graveAnimator;
    string revealedItem = null;

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
            GameObject junkInstance = Instantiate(junkPrefab, this.transform.position, Quaternion.identity);
            revealedItem = "Junk";
            Destroy(junkInstance, 2f);
            // junkInstance.transform.parent = this.transform;
            // junkInstance.transform.SetParent(this.transform, false);
            
        }
        else
        {
            print("found treasure");
            GameObject treasureInstance = Instantiate(treasurePrefab, this.transform.position, Quaternion.identity);
            FindObjectOfType<PileCounter>().FindTreasure();
            revealedItem = "Treasure";
            Destroy(treasureInstance, 2f);
            // treasureInstance.transform.parent = this.transform;
            // treasureInstance.transform.SetParent(this.transform, false);
        }
        //FindObjectOfType<PointsManager>().CalculatePoints(revealedItem);
    }

    private void PlayAnimation()
    {
        graveAnimator.SetTrigger("dig grave");
    }

}

  /*
        //GetComponentInChildren<ItemSpawner>();
        var foundItem = GetComponentInParent<GraveSpawner>().GetItemCopy();
        print(foundItem.transform.position);
        print("The found item is " + foundItem);
        //SpriteRenderer itemSprite = foundItem.GetSprite();
        // pointsManager.CalculatePoints(foundItem);
        */