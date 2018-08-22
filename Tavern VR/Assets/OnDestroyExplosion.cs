using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyExplosion : MonoBehaviour {
    GameObject mySplodeFect;
    AudioSource mySource;
    AudioSource splodeSource;
    public AudioClip myDeathClip;

    private void OnDestroy() {
        mySplodeFect = new GameObject("mySplode");
        mySplodeFect.AddComponent<AudioSource>();
        splodeSource = mySplodeFect.GetComponent<AudioSource>();
        splodeSource.volume = 0.25f;
        splodeSource.PlayOneShot(myDeathClip);
    }
}
