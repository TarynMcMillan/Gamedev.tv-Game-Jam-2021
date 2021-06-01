using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] TextMeshProUGUI quoteText;
    [SerializeField] LevelLoader levelLoader;
    string[] quotes = { "What a terrible night for a curse.", "This is not Castlevania." };
    float treasurePiles;
    float pilesRemaining;
   
    
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = levelLoader.GetComponent<LevelLoader>();
    }

    void Update()
    {
       
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
