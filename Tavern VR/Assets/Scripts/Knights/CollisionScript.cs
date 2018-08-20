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
    private float yResA;
    private float yResM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SwordBlade")       //Checking the tag on the object that it coliides with
        {
            startPos = other.transform.position;
            //startPos.y += yRes;
            //print("TriggerEnter");                    //For debugging 
            //tgtScript.movespeed = 0.20f;                //Slows the speed of the target
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "SwordBlade")        //Checking the tag on the object that it coliides with
        {
            endPos = other.transform.position;
            yResA = startPos.y + yResA + 0.20f;
            yResM = startPos.y + yResM - 0.20f;

            print(startPos.y + " StartPos");
            print(yResA + " Added");
            print(yResM + " Taken");
            print(endPos.y + " endpos");
            // Destroy(target, 3f);                        //Destroys the object "Target" after 3s (For performance)
            // targetBottomLeftRb.isKinematic = false;     //Disables kinematic so it falls apart
            //targetBottomRightRb.isKinematic = false;

        }
        if (other.gameObject.tag == "SwordBlade" && (endPos.z > startPos.z || endPos.z < startPos.z) && (endPos.y < yResA && endPos.y > yResM))        //Checking the tag on the object that it coliides with
        {
            print(startPos.y + " StartPos");
            print(yResA + " Added");
            print(yResM + " Taken");
            Destroy(target, 3f);                        //Destroys the object "Target" after 3s (For performance)
            targetBottomLeftRb.isKinematic = false;     //Disables kinematic so it falls apart
            targetBottomRightRb.isKinematic = false;
        }
        else
        {
            startPos = new Vector3(0, 0, 0);
            yResA = 0f;
            yResM = 0f;
        }
    }

}
