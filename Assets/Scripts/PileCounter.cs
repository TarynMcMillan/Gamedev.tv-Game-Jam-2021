using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] LevelLoader levelLoader;
    float junkPiles;
    float treasurePiles;
    float pilesRemaining;
   
    
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = levelLoader.GetComponent<LevelLoader>();
    }

    void Update()
    {
       if (pilesRemaining <= 0)
        {
            Time.timeScale = 0;
            levelLoader.StartRoundCompleteSequence();
        }
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
    }
}
