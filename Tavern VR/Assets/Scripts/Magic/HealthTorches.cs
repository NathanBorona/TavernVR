using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class HealthTorches : MonoBehaviour {
        Rigidbody tempRB;
        Vector3 myOgPos;
        Quaternion myOgRot;
        MeshRenderer myRend;
        public float myHealthPercentile;
        int myHealth;
        public int myMaxHealth;
        bool isDisabled = false;
        HealthParse myHealthReference;
        void Start() {
            myOgPos = transform.position;
            myOgRot = transform.rotation;
            myRend = GetComponentInChildren<MeshRenderer>();
            myHealthReference = GetComponentInParent<HealthParse>();
            myMaxHealth = myHealthReference.maxHealth;
            myHealth = myHealthReference.maxHealth;
            myHealthPercentile = myHealthPercentile * 0.01f * myMaxHealth;
        }

        
        void Update() {
            myHealth = myHealthReference.health;
            if (myHealth < myHealthPercentile && !isDisabled) {
                isDisabled = true;
                tempRB = gameObject.GetComponent<Rigidbody>();
                tempRB.AddForce(new Vector3(Random.Range(0f, 0.5f), Random.Range(1f, 1.5f), Random.Range(0f, 0.5f)) * tempRB.mass * 10f);
                tempRB.useGravity = true;
                gameObject.GetComponent<MagicBob>().enabled = false;
                myRend.material.color = new Color(myRend.material.color.r, myRend.material.color.g, myRend.material.color.b, 0f);
            }
            if (myHealth >= myHealthPercentile && isDisabled) {
                isDisabled = false;
                tempRB = gameObject.GetComponent<Rigidbody>();
                transform.position = myOgPos;
                transform.rotation = myOgRot;
                tempRB.useGravity = false;
                gameObject.GetComponent<MagicBob>().enabled = true;
                myRend.material.color = new Color(myRend.material.color.r, myRend.material.color.g, myRend.material.color.b, 0.75f);
                tempRB.velocity = Vector3.zero;
                tempRB.angularVelocity = Vector3.zero;
            }
        }
    }
}