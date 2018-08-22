namespace VRTK
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Cupcake : MonoBehaviour
    {

        public GameObject full;
        public GameObject bite1;
        public GameObject bite2;
        public GameObject bite3;
        public GameObject blur;
        public GameObject headset;
        public AudioSource Background;
        public float blurOut;
        public float time;
        float playSpeed = 0.75f;
        public bool offChops;

        // Use this for initialization
        void Start()
        {

            full.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            Eating();
            if (offChops == true)
            {
                High();
            }
        }

        public void Eating()
        {
            if ((headset.transform.position - transform.position).magnitude < 0.5f)
            {
                //if Glass is next to headset
                time = time + Time.deltaTime;
                if (time >= 4)
                {
                    bite3.SetActive(false);
                    blur.SetActive(true);
                    offChops = true;
                }
                else if (time >= 3)
                {
                    bite2.SetActive(false);
                    bite3.SetActive(true);
                }
                else if (time >= 2)
                {
                    bite1.SetActive(false);
                    bite2.SetActive(true);
                }
                else if (time >= 1)
                {
                    full.SetActive(false);
                    bite1.SetActive(true);
                }
                else if (time >= 0)
                {
                    full.SetActive(true);
                }
            }
        }

        public void High ()
        {
            blurOut = blurOut + Time.deltaTime;
            Time.timeScale = 0.75f;
            Background.pitch = playSpeed;
            if (blurOut >= 10)
            {
                Time.timeScale = 1f;
                Background.pitch = 1f;
                blur.SetActive(false);
                offChops = false;
            }
        }

    }
}