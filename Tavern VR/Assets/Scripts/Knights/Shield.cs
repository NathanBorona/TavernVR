﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public AudioSource shieldSound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Something");
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            Debug.Log("Hit Something");
            ShieldPlay();
        }
    }

    void ShieldPlay()
    {
        shieldSound.Play();
        Debug.Log("ShieldSound");
    }
}
