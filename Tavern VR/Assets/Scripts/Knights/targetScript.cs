using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {

    //public AudioSource deathAudioSource;
    //public GameObject myDeathEffect;
    public GameObject pole;
    public GameObject headset;
    public GameObject flag1;
    public GameObject flag2;
    public GameObject flag3;
    public Rigidbody part1;
    public Rigidbody part2;
    public Collider cube;
    public Collider caps;
    public int points;
    public int flags = 3;

    // Player Movement Variables/....
    public static int movespeed = 1;
    public Vector3 enemyDirection = Vector3.forward;
  

    // Use this for initialization
    void Start () {
        part1 = GetComponent<Rigidbody>();
        part2 = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        Move();
        Chop();
        Block();
        Player();
        Flag();
        Walls();
	}

    public void Chop ()
    {
        if (cube.gameObject.CompareTag("Sword") && caps.gameObject.CompareTag("Sword"))
        {
            points++;
            Destroy(pole, 1f);
            part1.isKinematic = false;
            part2.isKinematic = false;
        }
    }

    public void Block()
    {
        if (cube.gameObject.CompareTag("Shield") && caps.gameObject.CompareTag("Shield"))
        {
            Destroy(pole, 1f);
            part1.isKinematic = false;
            part2.isKinematic = false;
        }
    }

    public void Player()
    {
        if (pole.gameObject.CompareTag("Player"))
        {
            flags = flags - 1;
        }
    }

    public void Flag()
    {
        if (flags == 2)
        {
            flag1.transform.position = new Vector3(5.92f, -3.38f, -3.2f);
        }
        if (flags == 1)
        {
            flag1.transform.position = new Vector3(2.15f, -3.38f, -3.2f);
        }
        if (flags == 0)
        {
            flag1.transform.position = new Vector3(-1.8f, -3.38f, -3.2f);
        }
    }


    public void Walls()
    {
        if (gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject, 1f);
        }
    }

    // for moving enemy
    private void Move() {

        //add function here
        transform.Translate(enemyDirection * movespeed * Time.deltaTime);
    }

    // Kills enemy
    /*
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
    */


}
