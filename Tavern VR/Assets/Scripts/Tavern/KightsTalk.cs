using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KightsTalk : MonoBehaviour {

    public GameObject headset;
    public AudioSource kights;
    int once = 1;

	void Update () {
        Conversation();
	}

    public void Conversation ()
    {
        if (Vector3.Distance(headset.transform.position, transform.position) < 2f && once == 1)
        {
            kights.Play();
            Debug.Log("playing");
            once++;
        }
    }
}
