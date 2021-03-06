﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTenderTalk : MonoBehaviour {

    public GameObject headset;
    public AudioSource barTender;
    public AudioSource barTenderIntro;
    int once = 1;

    void Update()
    {
        Conversation();
    }

    private void Start()
    {
        
        AudioTracker.PlaySpeechAudio("DwarfIntro", barTenderIntro);
    }

    public void Conversation()
    {


        if (!barTenderIntro.isPlaying && Vector3.Distance(headset.transform.position, transform.position) < 2f && once == 1)
        {
            AudioTracker.PlaySpeechAudio("DwarfSpeak", barTender);
        }

    }
}
