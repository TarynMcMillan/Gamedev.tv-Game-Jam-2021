using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] LevelLoader levelLoader;
    GraveSpawner graveSpawner;
    float pilesRemaining;
    float treasurePiles;
    float junkPiles;
    void Start()
    {
        levelLoader = levelLoader.GetComponent<LevelLoader>();
        graveSpawner = FindObjectOfType<GraveSpawner>();
        GeneratePileCounter();
    }

    public void GeneratePileCounter()
    {
       
        treasurePiles = graveSpawner.GetTreasurePiles();
        junkPiles = graveSpawner.GetJunkPiles();

        print("The number of treasure piles is " + treasurePiles);
        print("The number of junk piles is " + junkPiles);

        pilesText.text = treasurePiles.ToString();
    }
    public void FindTreasure()
    {
        treasurePiles--;
        pilesText.text = treasurePiles.ToString();
        
        if (treasurePiles <= 0)
        {
            levelLoader.StartNextQuadrant();
            GeneratePileCounter();
        }
    }

    public void AddPile()
    {
        pilesRemaining++;
        pilesText.text = pilesRemaining.ToString();
    }
}
