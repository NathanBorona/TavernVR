using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    public GameObject target;
    public Rigidbody targetBottomLeftRb;
    public Rigidbody targetBottomRightRb;
    public targetScript tgtScript;


    private void OnTriggerEnter(Collider other)
    {

       
        if (other.gameObject.tag == "SwordBlade")
        {
            
            print("TriggerEnter");
            tgtScript.movespeed = 0.20f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "SwordBlade")
        {
            Destroy(target, 3f);
            targetBottomLeftRb.isKinematic = false;
            targetBottomRightRb.isKinematic = false;
        }
    }

}
