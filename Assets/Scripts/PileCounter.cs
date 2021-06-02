using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] TextMeshProUGUI quoteText;
    [SerializeField] LevelLoader levelLoader;
    string[] quotes = { "The sun’s rays break through the trees. You have survived the night.",
                        "Whatever evil lurks in the graveyard has been banished.",
                        "The night is over but the memory of loss remains.",
                        "Dirt on your hands, under your fingernails, inside your shoes. The life of a grave digger is never clean."
    };

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
        print("activating Find Treasure");
        pilesRemaining--;
        pilesText.text = pilesRemaining.ToString();
        if (pilesRemaining <= 0)
        {
            levelLoader.StartWinSequence();
            int randomQuoteFactor = Random.Range(0, quotes.Length);
            quoteText.text = quotes[randomQuoteFactor];
        }
    }
}
