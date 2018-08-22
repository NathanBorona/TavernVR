using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ribbit : MonoBehaviour {

    public AudioSource ribbit0;
    public AudioSource ribbit1;
    public AudioSource ribbit2;
    public AudioSource ribbit3;
    public AudioSource ribbit4;
    public AudioSource ribbit5;
    public AudioSource ribbit6;
    public AudioSource ribbit7;
    public AudioSource ribbit8;
    public AudioSource ribbit9;
    public float time;
    public int which;
    public int when;

    // Use this for initialization
    void Start () {
        when = Random.Range(6, 15);
        which = Random.Range(0, 10);
    }
	
    void Decider ()
    {
        when = Random.Range(6, 15);
        which = Random.Range(0, 10);
    }

	// Update is called once per frame
	void Update () {
        time = time + Time.deltaTime;

		if (time >= when)
        {
            if (which == 9)
            {
                ribbit0.Play();
                time = 0;
                Decider();
            }
            else if (which == 8)
            {
                ribbit1.Play();
                time = 0;
                Decider();
            }
            else if (which == 7)
            {
                ribbit2.Play();
                time = 0;
                Decider();
            }
            else if (which == 6)
            {
                ribbit3.Play();
                time = 0;
                Decider();
            }
            else if (which == 5)
            {
                ribbit4.Play();
                time = 0;
                Decider();
            }
            else if (which == 4)
            {
                ribbit5.Play();
                time = 0;
                Decider();
            }
            else if (which == 3)
            {
                ribbit6.Play();
                time = 0;
                Decider();
            }
            else if (which == 2)
            {
                ribbit7.Play();
                time = 0;
                Decider();
            }
            else if (which == 1)
            {
                ribbit8.Play();
                time = 0;
                Decider();
            }
            else if (which == 0)
            {
                ribbit9.Play();
                time = 0;
                Decider();
            }
        }
            
	}
}
