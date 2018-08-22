using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    public GameObject target;                           //Creating a reference to the target object
    
    public Rigidbody targetBottomLeftRb;                //Creating a reference to the targets Rigidbody (As i'm commenting this i realize i could've used target.gameObject.GetComponentsInChildren<Rigidbody>();)
    public Rigidbody targetBottomRightRb;               //Creating a reference to the targets Rigidbody (As i'm commenting this i realize i could've used target.gameObject.GetComponentsInChildren<Rigidbody>();)
    public Rigidbody targetTopRightRb;                  //Creating a reference to the targets Rigidbody (As i'm commenting this i realize i could've used target.gameObject.GetComponentsInChildren<Rigidbody>();)
    public Rigidbody targetTopLeftRb;                   //Creating a reference to the targets Rigidbody (As i'm commenting this i realize i could've used target.gameObject.GetComponentsInChildren<Rigidbody>();)

    public targetScript tgtScript;                      //Creating a reference to the TargetScript
    public HealthScript hpScript;
    public Score scoreScript;

    private Vector3 startPos;
    private Vector3 endPos;

    private float yResA;
    private float yResM;
    private float zResA;
    private float zResM;

    public bool upwards = false;
    public bool sideways = false;
    
    private void Start()
    {
        hpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>();
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SwordBlade")         //Checking the tag on the object that it coliides with
        {
            startPos = other.transform.position;          //Sets the start position when the object with tag Swordblade
            tgtScript.movespeed = 0.25f;                  //Slows the target to reduce the targets going thought the player
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "SwordBlade" && (sideways == true && upwards == false))        //Checking the tag on the object that it coliides with
        {
            endPos = other.transform.position;                    //Sets the endPos for later to compare values
            yResA = startPos.y + yResA + 0.50f;                   //Takes the start positions y axis and adds 0.40 to its value 
            yResM = startPos.y + yResM - 0.50f;                   //Takes the start positions y axis and takes 0.40 to its value
        }
        if (other.gameObject.tag == "SwordBlade" && (sideways == true && upwards == false) && (endPos.z > startPos.z || endPos.z < startPos.z) && (endPos.y < yResA && endPos.y > yResM))        //Checking the tag on the object that it coliides with
        {
            Destroy(target, 0.15f);                               //Destroys the object "Target" after .15s (For performance)
            scoreScript.score += 10;
            targetBottomLeftRb.isKinematic = false;               //Disables kinematic so it falls apart
            targetBottomRightRb.isKinematic = false;
        }
  
        if (other.gameObject.tag == "SwordBlade" && (sideways == false && upwards == true))        //Checking the tag on the object that it coliides with
        {
            endPos = other.transform.position;                  //Sets the endPos for later to compare values
            zResA = startPos.z + zResA + 0.50f;                 //Takes the start positions y axis and adds 0.40 to its value 
            zResM = startPos.z + zResM - 0.50f;                 //Takes the start positions y axis and takes 0.40 to its value
        }
        if (other.gameObject.tag == "SwordBlade" && (sideways == false && upwards == true) && (endPos.y > startPos.y || endPos.y < startPos.y) && (endPos.z < zResA && endPos.z > zResM))        //Checking the tag on the object that it coliides with
        {
            Destroy(target, 0.15f);                            //Destroys the object "Target" after .15s (For performance)
            scoreScript.score += 10;
            targetTopRightRb.isKinematic = false;              //Disables kinematic so it falls apart 
            targetBottomRightRb.isKinematic = false;
        }
        else
        {
            startPos = new Vector3(0, 0, 0);        //Reseting the values
            tgtScript.movespeed = 1.00f;
            zResA = 0f;
            zResM = 0f;
            yResA = 0f;
            yResM = 0f;
        }
    }
    /*private void OnDestroy()
    {
        scoreScript.score += 10;
    }*/
}
