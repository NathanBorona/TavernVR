using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAudio : MonoBehaviour {

    public AudioSource Knight;
    public int runOnce = 0;

    // Use this for initialization
    void Start () {

    }

	// Update is called once per frame
	void Update () {
        if (runOnce == 1)
        {
            Debug.Log("WTF");
            KnightPlay();
        }
    }

    void KnightPlay ()
    {

        Knight.Play();
        runOnce++;
    }
}
