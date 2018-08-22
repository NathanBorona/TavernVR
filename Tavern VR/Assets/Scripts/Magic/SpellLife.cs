using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLife : MonoBehaviour {
    public float lifetime;
    float timeAlive;
	void Start () {
        timeAlive = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timeAlive += Time.deltaTime;
        if (timeAlive >= lifetime)
        {
            Destroy(gameObject);
        }
	}
}
