using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    public GameObject target;                           //Creating a reference to the target object
    public Rigidbody targetBottomLeftRb;                //Creating a reference to the targets Rigidbody (As i'm commenting this i realize i could've used target.gameObject.GetComponentsInChildren<Rigidbody>();)
    public Rigidbody targetBottomRightRb;               //Creating a reference to the targets Rigidbody (As i'm commenting this i realize i could've used target.gameObject.GetComponentsInChildren<Rigidbody>();)
    public targetScript tgtScript;                      //Creating a reference to the TargetScript
    private Vector3 startPos;
    private Vector3 endPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SwordBlade")       //Checking the tag on the object that it coliides with
        {
            startPos = other.transform.position;
            //print("TriggerEnter");                    //For debugging 
            tgtScript.movespeed = 0.20f;                //Slows the speed of the target
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (other.gameObject.tag == "SwordBlade")        //Checking the tag on the object that it coliides with
        {
            endPos = other.transform.position;
           // Destroy(target, 3f);                        //Destroys the object "Target" after 3s (For performance)
           // targetBottomLeftRb.isKinematic = false;     //Disables kinematic so it falls apart
            //targetBottomRightRb.isKinematic = false;
            
        }
        if (other.gameObject.tag == "SwordBlade" && endPos.z < startPos.z || endPos.z > startPos.z)        //Checking the tag on the object that it coliides with
        {
        
            Destroy(target, 3f);                        //Destroys the object "Target" after 3s (For performance)
            targetBottomLeftRb.isKinematic = false;     //Disables kinematic so it falls apart
            targetBottomRightRb.isKinematic = false;

        }
    }

}
