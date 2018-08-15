using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {

    public AudioSource deathAudioSource;
    public GameObject myDeathEffect;

    // Player Movement Variables/....
    public static int movespeed = 1;
    public Vector3 enemyDirection = Vector3.forward;
  

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {

        Move();

	}

    // for moving enemy
    private void Move() {

        //add function here
        transform.Translate(enemyDirection * movespeed * Time.deltaTime);
    }

    // Kills enemy
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Sword")) {

            // We will flash red when hit and play a sound effect.
            //mySprite.color = Color.red;
            Invoke("ResetColour", 0.05f);
            deathAudioSource.Play();

            //invoke kill after 1 second
            Invoke("Kill", 1f);
        }

    }

        // Create our death effect and destroy ourself.
        protected void Kill() {
        Instantiate(myDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}
