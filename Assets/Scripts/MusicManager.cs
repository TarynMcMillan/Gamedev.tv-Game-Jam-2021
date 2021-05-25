using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    GameObject[] musicObject;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // TODO fix music loop skip
    }

    void Start()
    {
        musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObject.Length == 1)
        {

            GetComponent<AudioSource>().Play();
        }
        else
        {
            for (int i = 1; i < musicObject.Length; i++)
            {
                Destroy(musicObject[i]);
            }

        }
    }

    public void PauseMusic()
    {
        print("pausing music");
        GetComponent<AudioSource>().Pause();
    }

}
