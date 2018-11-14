using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSceneAudio : MonoBehaviour {

    public AudioSource knightsScene;

    // Use this for initialization
    private void Start()
    {
        AudioTracker.PlaySpeechAudio("KnightSceneSpeech", knightsScene);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
