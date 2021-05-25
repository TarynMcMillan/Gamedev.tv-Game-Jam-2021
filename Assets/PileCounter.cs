using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    float junkPiles;
    float treasurePiles;
    float pilesRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        
        print("There are " + junkPiles + "piles of Junk.");
        
        print("There are " + treasurePiles + "piles of Treasure.");
    */
        }

    // Update is called once per frame
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
    }
}
