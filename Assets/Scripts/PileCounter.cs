using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] LevelLoader levelLoader;
  
    float pilesRemaining;
    float treasurePiles;
    void Start()
    {
        levelLoader = levelLoader.GetComponent<LevelLoader>();
        print(this.name);
        
    }

    private void Update()
    {
        
    }
    public void GeneratePileCounter(float piles)
    {
        treasurePiles = FindObjectOfType<GraveSpawner>().GetDirtPiles();
        // print("There are " + treasurePiles + " piles remaining!");
        pilesRemaining = treasurePiles - piles;
        pilesText.text = pilesRemaining.ToString();
    }
    public void FindTreasure()
    {
        pilesRemaining--;
        pilesText.text = pilesRemaining.ToString();
        print("Found a treasure! There are " + treasurePiles + " piles remaining!");
        
        /*
        if (pilesRemaining <= 0)
        {
            levelLoader.StartWinSequence();
        }
        */
    }

    public void AddPile()
    {
        pilesRemaining++;
        pilesText.text = pilesRemaining.ToString();
    }
}
