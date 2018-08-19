using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    public GameObject target;
    public Rigidbody targetRb;
    public GameObject sword;

    public void Start()
    {
        Physics.IgnoreCollision(sword.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            Destroy(target,10f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            targetRb.isKinematic = false;
        }
    }

}
