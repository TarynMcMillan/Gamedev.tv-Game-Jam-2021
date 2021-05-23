using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grave : MonoBehaviour
{
    [SerializeField] AudioClip shovelSFX;
    [SerializeField] Treasure[] item;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gravePrefab;
    string[] color = new string[] { "Red", "Blue", "Green", "Black", "Yellow", "Purple" };
    PointsManager pointsManager;
    Treasure selectedItem;
    Animator graveAnimator;
    GameObject[] graves;
 

    private void Start()
    {
        pointsManager = slider.GetComponent<PointsManager>();
        graveAnimator = this.GetComponentInChildren<Animator>();
        // GenerateGraves();
    }
    public void DigGrave()
    {
        //PlayAnimation();
        RevealItem();
        PlaySFX();
    }

    private void PlaySFX()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = shovelSFX;
        audio.Play();
    }

    private void GenerateGraves()
    {
        foreach (GameObject grave in graves)
            {
            GameObject graveInstance = Instantiate(gravePrefab, transform.position, Quaternion.identity);
            GenerateItem();
        }
    }
    private void GenerateItem()
    {
        var randomFactor = Random.Range(0, item.Length);
        // AssignColor();
        selectedItem = item[randomFactor];
        SpriteRenderer itemSprite = selectedItem.GetSprite();
        pointsManager.CalculatePoints(selectedItem);
    }

    private void RevealItem()
    {
        // do something
    }
}
/*
private void PlayAnimation()
{
    graveAnimator.SetTrigger("open");
}


void AssignColor()
{
// var randomColorFactor = Random.Range(0, color.Length);
// var randomColor = color[randomColorFactor];
}
*/