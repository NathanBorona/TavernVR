using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject Target;
    public int rnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPos ()
    {
        rnd = Random.Range(1, 4);
        if (rnd == 1)
        {
            Instantiate(Target,new Vector3(-69f, 1.7f, 0f),Quaternion.Euler(0f, 90f, 0f));
        }
        if (rnd == 2)
        {
            Instantiate(Target, new Vector3(-3f, 1.7f, 5f), Quaternion.Euler(0f, 120f, 0f));
        }
        if (rnd == 3)
        {
            Instantiate(Target, new Vector3(3f, 1.7f, 5f), Quaternion.Euler(0f, 50f, 0f));
        }
    }
}
