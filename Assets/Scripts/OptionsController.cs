using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;
    [SerializeField] SplashScreen splashScreenManager;

    void Start()
    {
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<MusicManager>().PlayUISFX();
        splashScreenManager.LoadGame();
    }

}
/* todo do I need defaults?
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
*/