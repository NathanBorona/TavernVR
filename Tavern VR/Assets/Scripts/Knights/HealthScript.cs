﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public GameObject flag1;
    public GameObject flag2;
    public GameObject flag3;
    public int flags = 3;
    public SpawnScript sScript;
    public GameObject target1;
    public GameObject target2;

    public void Update()
    {
        TargetHit();
        Flag();
    }

    public void Flag()
    {
        if (flags == 2)
        {
            flag1.transform.position = new Vector3(3.76f, 0.74f, -5.24f);
        }
        if (flags == 1)
        {
            flag2.transform.position = new Vector3(1.12f, 0.74f, -5.24f);
        }
        if (flags == 0)
        {
            flag3.transform.position = new Vector3(-1.644f, 0.74f, -5.24f);
            sScript.run = false;
        }
    }

    public void TargetHit()
    {
        if ((target1.transform.position - transform.position).magnitude < 2f)
        {
            Debug.Log("ouchies");
            flags--;
            Destroy(target1);
        }
        if ((target2.transform.position - transform.position).magnitude < 2f)
        {

            Debug.Log("ouchies2");
            flags--;
            Destroy(target2);
        }
    }



    /*
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target")
        {
            flags--;
            Debug.Log("ouch");
        }
    } */
}
