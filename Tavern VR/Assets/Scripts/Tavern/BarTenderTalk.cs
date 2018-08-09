using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTenderTalk : MonoBehaviour {

    public GameObject headset;
    public AudioSource barTender;
    int once = 1;

    void Update()
    {
        Conversation();
    }

    public void Conversation()
    {
        if (Vector3.Distance(headset.transform.position, transform.position) < 2f && once == 1)
        {
            barTender.Play();
            Debug.Log("playing");
            once++;
        }
    }
}
