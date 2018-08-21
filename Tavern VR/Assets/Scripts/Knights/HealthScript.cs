using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public GameObject flag1;
    public GameObject flag2;
    public GameObject flag3;
    public int flags = 3;
    public SpawnScript sScript;

    public void Update()
    {
        if (flags == 0)
        {
            print(" Lost 3 flag");
            Destroy(GameObject.FindGameObjectWithTag("Target"));

        }
    }

    public void Flag()
    {
        if (flags == 2)
        {
            flag1.transform.position = new Vector3(3.76f, 0.74f, -5.24f);
            print(" Lost 1 flag"); 
        }
        if (flags == 1)
        {
            flag2.transform.position = new Vector3(1.12f, 0.74f, -5.24f);
            print(" Lost 2 flag");
        }
        if (flags == 0)
        {
            flag3.transform.position = new Vector3(-1.644f, 0.74f, -5.24f);
            print(" Lost 3 flag");
            Destroy(GameObject.FindGameObjectWithTag("Target"));
            sScript.run = false;

        }
    }
    
    private void OnCollisonEnter(Collision other)
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Something");
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            flags--;
            Debug.Log("ouch");
            Flag();
            
        }
    }
}
