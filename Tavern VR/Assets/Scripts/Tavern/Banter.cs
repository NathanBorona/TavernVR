using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banter : MonoBehaviour {

    public AudioSource knights;
    public AudioSource mages;
    public AudioSource barTenderIntro;
    public AudioSource barTender;
    public int playCount;

    public AudioSource ribbit0;
    public AudioSource ribbit1;
    public AudioSource ribbit2;
    public AudioSource ribbit3;
    public AudioSource ribbit4;
    public AudioSource ribbit5;
    public AudioSource ribbit6;
    public float time;
    public int which;
    public int when;

    private void Start()
    {
        when = Random.Range(60, 180);
        which = Random.Range(0, 7);
    }

    void Update()
    {
        time = time + Time.deltaTime;
        Conversation();
        if (knights.isPlaying == true)
        {
            playCount++;
        }
        if (mages.isPlaying == true)
        {
            playCount++;
        }
        if (barTender.isPlaying == true)
        {
            playCount++;
        }
        if (barTenderIntro.isPlaying == true)
        {
            playCount++;
        }
    }

    public void Conversation()
    {


        if (!barTenderIntro.isPlaying && !barTender.isPlaying && !mages.isPlaying && !knights.isPlaying)
        {
            if (playCount >= 17800)
            {
                TalkingCrap();
            }

        }
    }

    void TalkingCrap ()
    {
        if (time >= when)
        {
            if (which == 6)
            {
                ribbit0.Play();
                time = 0;
                Decider();
            }
            else if (which == 5)
            {
                ribbit1.Play();
                time = 0;
                Decider();
            }
            else if (which == 4)
            {
                ribbit2.Play();
                time = 0;
                Decider();
            }
            else if (which == 3)
            {
                ribbit3.Play();
                time = 0;
                Decider();
            }
            else if (which == 2)
            {
                ribbit4.Play();
                time = 0;
                Decider();
            }
            else if (which == 1)
            {
                ribbit5.Play();
                time = 0;
                Decider();
            }
            else if (which == 0)
            {
                ribbit6.Play();
                time = 0;
                Decider();
            }
        }
    }

    void Decider()
    {
        when = Random.Range(60, 180);
        which = Random.Range(0, 7);
    }
}
