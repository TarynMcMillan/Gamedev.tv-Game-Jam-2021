using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overworld : MonoBehaviour
{
    public void LoadGraveyard()
    {
        SceneManager.LoadScene("Graveyard");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Splash Screen");
    }
    
}
