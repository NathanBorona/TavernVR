using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class Enemy : MonoBehaviour {


	// The enemies speed value.
	public float mySpeed = 4f;

	// Our enemies health.
	public int myHealth = 3;

	// A reference to our enemies sprite object.
	public SpriteRenderer mySprite;

	// A reference to our death effect prefab.
	public GameObject myDeathEffect;

	public GameObject myLaser;

	// The enemies motion vector.
	protected Vector2 myMotion = Vector2.zero;

	// A reference to the enemies rigid body for physics based collision detection.
	Rigidbody2D myRigidbody;

	// A reference to our audio source so we can play a hurt sound effect.
	AudioSource myHurtAudioSource;


	// Use this for initialization
	protected void Start () {
		// We assign our references to our components we intend to use later.
		myRigidbody = GetComponent<Rigidbody2D> ();
		myHurtAudioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Run the move function.  This will be overriden by child classes.
		Move ();
	
	}

	// We use physics to update our movement.
	void FixedUpdate() {
		myRigidbody.velocity = myMotion;
	}

	// This handles collisions with bullets.
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.CompareTag ("Bullet")) {
			myHealth -= 1; // Remove one health

			// We will flash red when hit and play a sound effect.
			mySprite.color = Color.red;
			Invoke("ResetColour", 0.05f);
			myHurtAudioSource.Play ();

			// If our health dropped to 0.
			if(myHealth <= 0){
				Kill ();	
			}
		}

		if (collider.gameObject.CompareTag ("Super")) {
			myHealth -= 3; // Remove three health

			// We will flash red when hit and play a sound effect.
			mySprite.color = Color.red;
			Invoke ("ResetColour", 0.05f);
			myHurtAudioSource.Play ();

			// If our health dropped to 0.
			if (myHealth <= 0) {
				Kill ();
			}
		}
	}

	// We only want to flash red, so we reset to white after a brief moment by invoking this method.
	void ResetColour() {
		mySprite.color = Color.white;
	}

	// We will override this function to perform different movement actions for different enemies.
	protected virtual void Move(){
		myMotion = Vector3.down * mySpeed;
	}

	// Create our death effect and destroy ourself.
	protected void Kill() {
		Instantiate (myDeathEffect, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
