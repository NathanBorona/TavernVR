using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageInstructions : MonoBehaviour {

    public AudioSource mageScene;

    // Use this for initialization
    private void Start()
    {
        AudioTracker.PlaySpeechAudio("MageSceneInstructions", mageScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
