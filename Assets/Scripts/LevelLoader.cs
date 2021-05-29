using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip UISFX;
    [SerializeField] GameObject roundCompletePanel;
    [SerializeField] GameObject helpPanel;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartRoundCompleteSequence()
    {
        
        ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
        print(ps.Length);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }
        var gameTimer = FindObjectOfType<GameTimer>();
        //stop timer
        //Time.timeScale = 0;
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
        helpPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseHelpPanel()
    {
        PlayUISFX();
        helpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlayUISFX()
    {
        print("playing UI SFX");
        audioSource.PlayOneShot(UISFX, 1f);
    }

}
