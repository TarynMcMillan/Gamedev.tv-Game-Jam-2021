using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "Treasure", order = 0)]
public class Treasure : ScriptableObject
{
    [SerializeField] float points;
    [SerializeField] string treasureName;
    [SerializeField] bool isJunk = true;

    public string GetName()
    {
        return treasureName;
    }
    public float GetPoints()
    {
        return points;
    }
    public bool GetIsJunk()
    {
        return isJunk; 
    }


}
