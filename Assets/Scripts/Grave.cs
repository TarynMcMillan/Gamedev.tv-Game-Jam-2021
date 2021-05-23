using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grave : MonoBehaviour
{
    [SerializeField] AudioClip shovelSFX;
    [SerializeField] Treasure[] item;
    [SerializeField] Slider slider;
    string[] color = new string[] { "Red", "Blue", "Green", "Black", "Yellow", "Purple" };
    PointsManager pointsManager;
    Treasure selectedItem;
    Animator graveAnimator;

    private void Start()
    {
        pointsManager = slider.GetComponent<PointsManager>();
        graveAnimator = this.GetComponentInChildren<Animator>();
    }
    public void DigGrave()
    {
        //PlayAnimation();
        GenerateItem();
        PlaySFX();
    }

    private void PlaySFX()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = shovelSFX;
        audio.Play();
    }

    private void GenerateItem()
    {
        var randomFactor = Random.Range(0, item.Length);
        var randomColor = Random.Range(0, color.Length);
        selectedItem = item[randomFactor];
        if (selectedItem.IsJunk())
        {
            print("The item is junk");
        }
        else
        {
            SpriteRenderer itemSprite = selectedItem.GetSprite();
            itemSprite.color = new color[randomColor];
            // TODO fix this
        }
        pointsManager.CalculatePoints(selectedItem);
    }
    /*
    private void PlayAnimation()
    {
        graveAnimator.SetTrigger("open");
    }
    */
}
