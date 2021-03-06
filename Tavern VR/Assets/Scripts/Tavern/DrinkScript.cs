﻿namespace VRTK
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DrinkScript : MonoBehaviour
    {

        public GameObject full;
        public GameObject quaters;
        public GameObject half;
        public GameObject quater;
        public GameObject foam;
        public GameObject empty;

        public GameObject headset;
        public float countDown = 6;
        public float time;
        public bool Drinkingbool;

        public AudioSource drinkSound;

        // Use this for initialization
        void Start()
        {

            full.SetActive(true);
            Drinkingbool = false;
        }

        // Update is called once per frame
        void Update()
        {
            Drinking();

            if (Drinkingbool == true)
            {
                DrinkPlay();
                Drinkingbool = false;
            }
            else {
                Drinkingbool = false; 
            }
        }

        public void Drinking()
        {
            if ((headset.transform.position - transform.position).magnitude < 0.5f)
            {
                //if Glass is next to headset
                //gameObject.transform.rotation (0, -90, 0);
                time = time + Time.deltaTime;

                if (time >= 5)
                {
                    foam.SetActive(false);
                    empty.SetActive(true);

                }
                else if (time >= 4)
                {
                    quater.SetActive(false);
                    foam.SetActive(true);

                }
                else if (time >= 3)
                {
                    half.SetActive(false);
                    quater.SetActive(true);

                }
                else if (time >= 2)
                {
                    quaters.SetActive(false);
                    half.SetActive(true);

                }
                else if (time >= 1)
                {
                    full.SetActive(false);
                    quaters.SetActive(true);

                }
                else if (time >= 0)
                {
                    full.SetActive(true);

                }
            }
               

        }

        void DrinkPlay() {
            drinkSound.Play();
            drinkSound = GameObject.FindGameObjectWithTag("Drink").GetComponent<AudioSource>();
            Debug.Log("DrinkSoundPlay");
        }
    }

}
