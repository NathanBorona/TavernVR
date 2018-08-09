using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioSource deathAudioSource;
    public GameObject myDeathEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //Add function to move enemy forward

	}

    private void OnTriggerEnter(Collider other)
    {
        //if player is passes enemy trigger and health is greater than 0
        if (other.gameObject.CompareTag("Sword"))
        {
            Kill();
        }
    }

    // Create our death effect and destroy ourself.
    protected void Kill()
    {
        Instantiate(myDeathEffect, transform.position, Quaternion.identity);
        deathAudioSource.Play();
        Destroy(gameObject);
    }
}
