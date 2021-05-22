using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grave : MonoBehaviour
{
    [SerializeField] AudioClip shovelSFX;
    [SerializeField] Treasure[] item;
    [SerializeField] Slider slider;
    PointsManager pointsManager;
    Treasure selectedItem;

    private void Start()
    {
        pointsManager = slider.GetComponent<PointsManager>();
    }
    public void DigGrave()
    {
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
        selectedItem = item[randomFactor];
        pointsManager.CalculatePoints(selectedItem);
    }

}
