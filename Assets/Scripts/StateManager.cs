using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateManager
{
    public static GameObject creatures;

    public static GameObject Creatures
    {
        get
        {
            return creatures;
        }
        set
        {
            creatures = value;
        }
    }
}
