using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OrientationLineJudge : MonoBehaviour {
    //Script for drawing and judging magic lines WIP.
    //I may reconsider this script and put it on the lines instead. still trying to think of way to make this work.

    enum LineState {Start, Draw, Clean};
    LineState myState;
    //Enum for switch statement. states of drawing - start, draw, and clean. judge state is defined by trigger end event.

    Vector3 lineStPos;
    Vector3 lineEnPos;
    GameObject tempRight;
    GameObject tempLeft;
    public float maxDrawDist;
    int curPosIndex;
    GameObject tempLine;
    LineRenderer lineRend;
    Transform startTransf;
    Transform currentTransf;
    bool startAllowed;

    void Awake () {
        AssignVariablesMisc();
        myState = LineState.Start;
	}

    void AssignVariablesMisc() {
        /*personal preference: I like to define all of my misc variables in a 
        collapsable function so they're not in the way if I'm looking for something in code.*/
        lineStPos = Vector3.zero;
        lineEnPos = Vector3.zero;
        curPosIndex = 0; //makes sure the current index position for drawing lines is set to 0 at the start.
        tempRight = GameObject.FindGameObjectWithTag("RightController");
        tempLeft = GameObject.FindGameObjectWithTag("LeftController");
        lineStPos = Vector3.zero;
        lineEnPos = Vector3.zero;
    }

    void Update () {
        switch (myState) {
            case LineState.Start:
                startAllowed = true;
                break;
            case LineState.Draw:
                currentTransf = tempLeft.transform; //but actually please use the controller's transform
                DrawLine();
                break;
            case LineState.Clean:
                CleanUp();
                startTransf = transform;
                currentTransf = transform;
                break;
        }
	}

    void CleanUp() {
        //resets all changed variables to what they were at the start.
        Destroy(tempLine);
        curPosIndex = 0;
        startAllowed = true;
        myState = LineState.Start;
    }

    public void StartLine() { //TO BE USED on trigger press stay event
        if (startAllowed) {
            startTransf = tempLeft.transform; //but actually please use the controller's transform
            //when the crystal is used - how do I do the thing where you check if trigger is pressed/recieve events from VRTK?
            //get the current color (enum stored in either this or another script using the touchpad)
            tempLine = Instantiate(new GameObject("line"), startTransf.position, startTransf.rotation);
            //creates an object "line" and assigns it to tempLine for use later.
            lineRend = tempLine.AddComponent<LineRenderer>();
            //adds a line renderer to "line" to use as "drawing magic" system.
            lineRend.SetPosition(curPosIndex, startTransf.position);
            //sets the first point of the line to the same position as the controller
            curPosIndex++;
            myState = LineState.Draw;
            startAllowed = false;
        }
    }

    void DrawLine() {
        if (Vector3.Distance(currentTransf.position, lineRend.GetPosition(curPosIndex)) > maxDrawDist) {
            lineRend.SetPosition(curPosIndex, currentTransf.position);
            curPosIndex++;
        }
    }



    public void StopDraw() { //TO BE USED on trigger press end event
        //on stop pressing trigger
        //judge line and instantiate effect
        lineEnPos = lineRend.GetPosition(curPosIndex);
        lineStPos = lineRend.GetPosition(0);
        //need to translate these two into a plane, then figure out if, on the plane, they're going up or down. plane as in local axis. could also use controller axis?
        //having trouble, need help with this one.
        myState = LineState.Clean;
    }
}
