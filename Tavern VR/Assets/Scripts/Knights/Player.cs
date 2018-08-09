using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int lives; // player lives
    public GameObject heart1; // for displaying lives
    public GameObject heart2;
    public GameObject heart3;
    public float myTimer; 
    public bool isBlocking; // to detect if player is blocking 
    public AudioSource hitAudio; // to trigger audio when hit by enemy
    public AudioSource deathAudio; // for triggering audio for when player dies 
    public GameObject myDeathEffect; //effect for player death

    // Use this for initialization
    void Start () {

        lives = 3;
        isBlocking = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        myTimer += Time.deltaTime;
        Debug.Log(myTimer);

        Lives();

	}

    //For showing active remaining lives
    public void Lives()
    {
        if (lives == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        if (lives == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        if (lives == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        if (lives == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //if player is passes enemy trigger and health is greater than 0
        if (other.gameObject.CompareTag("Enemy") && lives > 0 && isBlocking == false)
        {
            lives -= 1;
            hitAudio.Play();
        }
    }
}
