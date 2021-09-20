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
        print("Generating Pile Counter");
        treasurePiles = graveSpawner.GetTreasurePiles();
        junkPiles = graveSpawner.GetJunkPiles();
        pilesText.text = treasurePiles.ToString();
        
        // print("There are " + junkPiles + " Junk piles remaining");
    }
    public void FindTreasure()
    {
        print("There are " + treasurePiles + " Treasure piles remaining");
        treasurePiles--;
        pilesText.text = treasurePiles.ToString();
        // print("Found a treasure! There are " + treasurePiles + " piles remaining!");
        
        if (treasurePiles <= 0)
        {
            levelLoader.StartNextQuadrant();
            GeneratePileCounter();
        }
        if(graveSpawner.quadrantNumber == graveSpawner.maxQuadrant)
        {
            levelLoader.StartWinSequence();
        }
    }

    public void AddPile()
    {
        pilesRemaining++;
        pilesText.text = pilesRemaining.ToString();
    }
}
