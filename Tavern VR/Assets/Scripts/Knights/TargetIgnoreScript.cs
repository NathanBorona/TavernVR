using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIgnoreScript : MonoBehaviour {

    private GameObject sword;

    public void Start()
    {
        sword = GameObject.FindGameObjectWithTag("SwordBlade");
        Physics.IgnoreCollision(sword.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
