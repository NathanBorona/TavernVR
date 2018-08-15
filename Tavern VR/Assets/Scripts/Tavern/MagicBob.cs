using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBob : MonoBehaviour
{
    [SerializeField] float maxHeight = .1f;
    [SerializeField] float minHeight = .1f;
    [SerializeField] float bobSpeed = .5f;
    float targetHeight;
    float currentBobSpeed;
    float distanceFromTarget;
    
    //TODO find better way of making bobspeed positive or negative
    //TODO is there a better way of translating the transform between the max and min?
    //TODO is there a way to slow down the up/down movement as it's closer to max and min
    //TODO can you add some randomness/noise to how far up/down it goes, and/or to whether it starts up or down


    private void Awake()
    {
        // Set target heights relative to the object's starting height
        maxHeight = transform.position.y + maxHeight;
        minHeight = transform.position.y - minHeight;
        targetHeight = maxHeight;
        bobSpeed = bobSpeed * Random.Range(0.5f, 1.5f) * 0.5f;
        currentBobSpeed = bobSpeed;
        
    }

    void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * currentBobSpeed);

        // Check to see if we're bobbing up
        if (targetHeight == maxHeight)
        {
            // if height is greater than max height then swap target to minheight
            if (transform.position.y >= targetHeight)
            {
                targetHeight = minHeight;
                currentBobSpeed = bobSpeed - (bobSpeed * 2);
            }

        }
        // or if we're bobbing down
        else if (targetHeight == minHeight)
        {
            // if height is less than min height then swap target to maxheight
            if (transform.position.y <= targetHeight)
            {
                targetHeight = maxHeight;
                currentBobSpeed = bobSpeed; 
            }

        }

    }
}
