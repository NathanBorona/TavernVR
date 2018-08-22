using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KightsTalk : MonoBehaviour {

    public GameObject headset;
    public AudioSource knights;
    public AudioSource mages;
    public AudioSource barTenderIntro;
    public AudioSource barTender;
    int once = 1;

	void Update () {
        Conversation();
	}

    public void Conversation ()
    {
        if ((!barTenderIntro.isPlaying && !barTender.isPlaying && !mages.isPlaying) && Vector3.Distance(headset.transform.position, transform.position) < 2f && once == 1)
        {
            AudioTracker.PlaySpeechAudio("KnightSpeak", knights);
        }
    }
}
