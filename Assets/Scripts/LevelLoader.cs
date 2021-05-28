using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip UISFX;
    [SerializeField] GameObject roundCompletePanel;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartRoundCompleteSequence()
    {
        roundCompletePanel.SetActive(true);
        audioSource.PlayOneShot(winSFX, 1f);
        // todo make sure particle effects finish before time stops
    }
    public void LoadGame()
    {
        Time.timeScale = 1;
        PlayUISFX();
        SceneManager.LoadScene("Graveyard");
        // todo add scene fade
    }
    public void LoadMainMenu()
    {
        PlayUISFX();
        SceneManager.LoadScene("Splash Screen");
    }

    public void OpenHelpPanel()
    {
        PlayUISFX();
    }

    public void PlayUISFX()
    {
        print("playing UI SFX");
        audioSource.PlayOneShot(UISFX, 1f);
    }

}
