using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTracker : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static void ResetPlayerPrefs(string checkKey)
    {
        PlayerPrefs.SetInt(checkKey, 0);

    }


    public static void PlaySpeechAudio(string checkKey, AudioSource myAudioSource){
        if (!PlayerPrefs.HasKey(checkKey))
        {
            myAudioSource.Play();
            PlayerPrefs.SetInt(checkKey, 1);

        }
        else
        {
            if (PlayerPrefs.GetInt(checkKey) == 0)
            {
                myAudioSource.Play();
                PlayerPrefs.SetInt(checkKey, 1);
            }
            else
            {
                return;
            }
        }
        
    }
}
