using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour {




    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);

        }
    }

}
