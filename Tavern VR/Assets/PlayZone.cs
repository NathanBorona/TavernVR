using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour {

    private void OnTriggerExit(Collider collision) {
        Destroy(collision.gameObject);
    }
}
