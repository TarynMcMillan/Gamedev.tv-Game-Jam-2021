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
    [SerializeField] GameObject fadeCanvas;
    AudioSource audioSource;
    Animator transition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transition = fadeCanvas.GetComponent<Animator>();
    }
    public void StartRoundCompleteSequence()
    {
        
        ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
        print(ps.Length);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }
        FindObjectOfType<GameTimer>().triggeredLevelFinished = true;
        //Time.timeScale = 0;
        roundCompletePanel.SetActive(true);
        audioSource.PlayOneShot(winSFX, 1f);
        // todo make sure particle effects finish before time stops
    }
    public void LoadGame()
    {
        Time.timeScale = 1;
        PlayUISFX();
        StartCoroutine(FadeScene());
        SceneManager.LoadScene("Graveyard");
    }

    IEnumerator FadeScene()
    {
        transition.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
    }

    public void LoadMainMenu()
    {
        PlayUISFX();
        StartCoroutine(FadeScene());
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
