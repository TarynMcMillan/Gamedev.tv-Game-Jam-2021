using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "Treasure", order = 0)]
public class Treasure : ScriptableObject
{
    [SerializeField] float points;
    [SerializeField] string treasureName;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] bool isJunk = true;

    public string GetName()
    {
        return treasureName;
    }
    public float GetPoints()
    {
        return points;
    }
    public bool IsJunk()
    {
        return isJunk; 
    }

    public SpriteRenderer GetSprite()
    {
        return sprite;
    }    

}
