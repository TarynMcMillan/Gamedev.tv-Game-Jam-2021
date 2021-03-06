using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip UISFX;
    [SerializeField] AudioClip loseSFX;
    [SerializeField] GameObject roundCompletePanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject fadeCanvas;
    [SerializeField] Button helpButton;
    [SerializeField] GraveSpawner graveSpawner;
    [SerializeField] Lantern lantern;
    CameraController cameraController;
    AudioSource audioSource;
    Animator transition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transition = fadeCanvas.GetComponent<Animator>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        // this.transform.position = Camera.main.transform.position;
    }

    public void StartNextQuadrant()
    {
        print("Starting the Next Quadrant sequence");
        cameraController.NextPosition();
        graveSpawner.quadrantNumber++;
        graveSpawner.GenerateQuadrant();
        lantern.ResetCharges();
    }

    public void StartWinSequence()
    {
        
        ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
        print(ps.Length);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }
        FindObjectOfType<GameTimer>().timerStopped = true;
        roundCompletePanel.SetActive(true);
        audioSource.clip = winSFX;
        audioSource.Play();
        //audioSource.PlayOneShot(winSFX, 1f);
    }

    public void StartLoseSequence()
    {
        ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
        // print(ps.Length);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].Stop();
        }
        FindObjectOfType<GameTimer>().timerStopped = true;
        losePanel.SetActive(true);
        audioSource.PlayOneShot(loseSFX, 1f);
        //PlayLoseSFX();
    }

    void PlayLoseSFX()
    {
        audioSource.clip = loseSFX;
        audioSource.Play();
        //audioSource.PlayOneShot(loseSFX, 1f);
    }

    public void LoadGame()
    {
        Time.timeScale = 1;
        FindObjectOfType<MusicManager>().PlayUISFX();
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
        Time.timeScale = 1;
        FindObjectOfType<MusicManager>().PlayUISFX();
        StartCoroutine(FadeScene());
        SceneManager.LoadScene("Splash Screen");
    }

    public void OpenHelpPanel()
    {
            PlayUISFX();
            helpPanel.SetActive(true);
            helpButton.interactable = false;
            Time.timeScale = 0;
            ParticleSystem[] ps = FindObjectsOfType<ParticleSystem>();
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].Stop();
            }
            FindObjectOfType<GameTimer>().timerStopped = true;
    }

    public void CloseHelpPanel()
    {
        PlayUISFX();
        helpPanel.SetActive(false);
        Time.timeScale = 1;
        helpButton.interactable = true;
        FindObjectOfType<GameTimer>().timerStopped = false;
    }

    public void LoadOverworld()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void PlayUISFX()
    {
        print("playing UI SFX");
        audioSource.PlayOneShot(UISFX, 1f);
    }

}
