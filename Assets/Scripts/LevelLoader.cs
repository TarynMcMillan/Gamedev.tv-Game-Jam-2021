using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void StartRoundCompleteSequence()
    {
        this.gameObject.SetActive(true);
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene("Graveyard");
        // todo add scene fade
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Splash Screen");
    }

}
