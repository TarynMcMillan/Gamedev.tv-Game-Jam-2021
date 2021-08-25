using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] LevelLoader levelLoader;
  

    float treasurePiles;
    float pilesRemaining;
    void Start()
    {
        levelLoader = levelLoader.GetComponent<LevelLoader>();
    }
    public void GeneratePileCounter(float piles)
    {
        treasurePiles = FindObjectOfType<GraveSpawner>().GetDirtPiles();
        pilesRemaining = treasurePiles - piles;
        pilesText.text = pilesRemaining.ToString();
    }
    public void FindTreasure()
    {
        // print("activating Find Treasure");
        pilesRemaining--;
        pilesText.text = pilesRemaining.ToString();
        if (pilesRemaining <= 0)
        {
            levelLoader.StartWinSequence();
        }
    }
}
