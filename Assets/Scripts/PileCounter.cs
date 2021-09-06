using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pilesText;
    [SerializeField] LevelLoader levelLoader;
  
    public float pilesRemaining;
    float treasurePiles;
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
        pilesRemaining--;
        pilesText.text = pilesRemaining.ToString();
        if (pilesRemaining <= 0)
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
