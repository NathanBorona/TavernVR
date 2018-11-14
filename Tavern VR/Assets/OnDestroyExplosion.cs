using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyExplosion : MonoBehaviour {
    OnDestroyExplosion explosionSplodeBoom;
    GameObject mySplodeFect;
    AudioSource mySource;
    AudioSource splodeSource;
    public AudioClip myDeathClip;
    public bool isExplosion = false;
    public float myTimer = 5f;
    float myTime = 0f;

    private void Update() {
        if (isExplosion) {
            myTime += Time.deltaTime;
            if (myTime >= myTimer) {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy() {
        if (!isExplosion) {
            mySplodeFect = new GameObject("mySplode");
            mySplodeFect.AddComponent<AudioSource>();
            splodeSource = mySplodeFect.GetComponent<AudioSource>();
            splodeSource.volume = 0.25f;
            splodeSource.PlayOneShot(myDeathClip);
            mySplodeFect.AddComponent<OnDestroyExplosion>();
            explosionSplodeBoom = mySplodeFect.GetComponent<OnDestroyExplosion>();
            explosionSplodeBoom.isExplosion = true;
        }
    }
}
