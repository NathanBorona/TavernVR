using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour {

    //public AudioSource deathAudioSource;
    //public GameObject myDeathEffect;
    public GameObject pole;
    public GameObject headset;
   /* public Rigidbody part1;
    public Rigidbody part2;
    public Collider cube;
    public Collider caps; */
    public int points;
    

    // Player Movement Variables/....
    public float movespeed = 1f;
    public Vector3 enemyDirection = Vector3.forward;
  

    // Use this for initialization
    /*
    void Start () {
        part1 = GetComponent<Rigidbody>();
        part2 = GetComponent<Rigidbody>();
    }
    */
	
	// Update is called once per frame
	void Update () {

        Move();
        //Chop();
        //Block();
        Player();
        Walls();
	}
    /*
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
    */

    public void Player()
    {
        /*if (pole.gameObject.CompareTag("Player"))
        {
          
        }*/
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

    


}
