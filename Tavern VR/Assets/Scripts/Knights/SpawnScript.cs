using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] Target;
    public int rnd;
    public int rnd2;
    public float incroment = 10f;
    public float timer;
    public float cont;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        cont += Time.deltaTime;

        Difficulty();
        if (timer >= incroment)
        {
            TargetSelect();
        }
	}

    public void Difficulty()
    {
        if (cont >= 600)
        {
            incroment = 0.5f;
        }
        if (cont >= 300)
        {
            incroment = 0.8f;
        }
        else if (cont >= 180)
        {
            incroment = 1f;
        }
        else if (cont >= 120)
        {
            incroment = 2f;
        }
        else if (cont >= 60)
        {
            incroment = 3f;
        }
        else if (cont >= 20)
        {
            incroment = 5f;
        }
    }

    public void SpawnPos(GameObject objectToSpawn)
    {
        rnd = Random.Range(1, 4);
        if (rnd == 1)
        {
            Instantiate(objectToSpawn, new Vector3(-5f, 1.7f, 0f), Quaternion.Euler(0f, 90f, 0f));
            timer = 0;
        }
        else if (rnd == 2)
        {
            Instantiate(objectToSpawn, new Vector3(-5f, 1.7f, 5f), Quaternion.Euler(0f, 120f, 0f));
            timer = 0;
        }
        else if (rnd == 3)
        {
            Instantiate(objectToSpawn, new Vector3(-5f, 1.7f, -5f), Quaternion.Euler(0f, 60f, 0f));
            timer = 0;
        }
    }

        public void TargetSelect ()
        {
        rnd2 = Random.Range(1, 3);
            if (rnd2 == 1)
            {
            SpawnPos(Target[0]);
            }
            else if (rnd2 == 1)
            {
            SpawnPos(Target[1]);
            }
        }
}
