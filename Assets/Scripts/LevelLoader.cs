using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void StartRoundCompleteSequence()
    {
        this.gameObject.SetActive(true);
        // todo make sure particle effects finish before time stops
    }
    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Graveyard");
        // todo add scene fade
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Splash Screen");
    }

}
