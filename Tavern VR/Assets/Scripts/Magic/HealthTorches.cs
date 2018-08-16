using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class HealthTorches : MonoBehaviour {
        Rigidbody tempRB;
        MeshRenderer myRend;
        public float myHealthPercentile;
        int myHealth;
        public int myMaxHealth;
        bool isDisabled = false;
        HealthParse myHealthReference;
        void Start() {
            myRend = GetComponentInChildren<MeshRenderer>();
            myHealthReference = GetComponentInParent<HealthParse>();
            myMaxHealth = myHealthReference.maxHealth;
            myHealth = myHealthReference.maxHealth;
            myHealthPercentile = myHealthPercentile * 0.01f * myMaxHealth;
        }

        
        void Update() {
            myHealth = myHealthReference.health;
            if (myHealth <= myHealthPercentile && !isDisabled) {
                isDisabled = true;
                tempRB = gameObject.GetComponent<Rigidbody>();
                tempRB.AddForce(Vector3.up * 20f);
                tempRB.useGravity = true;
                gameObject.GetComponent<MagicBob>().enabled = false;
                myRend.material.color = new Color(myRend.material.color.r, myRend.material.color.g, myRend.material.color.b, 0f);
            }
        }
    }
}