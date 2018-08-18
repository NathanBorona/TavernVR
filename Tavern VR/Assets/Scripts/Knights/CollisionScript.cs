using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {


    public Material material;

    public void Start()
    {
        material.color = Color.green;
    }

    private void OnCollisionStart(Collision collision)
    {
        foreach(ContactPoint hitpos in collision.contacts)
        {
            if (hitpos.point.z - transform.position.z < 0)
            {
                Debug.Log(hitpos.point.z);
                material.color = Color.blue;
            }
            else {
                material.color = Color.green;
                 }
        }



    }






}
