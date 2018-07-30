using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OrientationLineJudge : MonoBehaviour {
    GameObject tempRight;
    GameObject tempLeft;
    enum LineState {Start, Draw, Clean};
    LineState myState;

    public float maxDrawDist;

    int curPosIndex;
    GameObject tempLine;
    LineRenderer lineRend;
    bool startAllowed;

    Transform startTransf;
    Transform currentTransf;
    void Awake () {
        myState = LineState.Start;
        curPosIndex = 0;
        tempRight = GameObject.FindGameObjectWithTag("RightController");
        tempLeft = GameObject.FindGameObjectWithTag("LeftController");
	}

	void Update () {
        switch (myState) {
            case LineState.Start:
                startTransf = tempLeft.transform; //but actually please use the controller's transform
                startAllowed = true;
                break;
            case LineState.Draw:
                currentTransf = transform; //ditto
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
        Destroy(tempLine);
        curPosIndex = 0;
        startAllowed = true;
        myState = LineState.Start;
    }

    public void StartLine() {
        if (startAllowed) {
            //when the crystal is used - how do I do the thing where you check if trigger is pressed/recieve events from VRTK?
            //get the current color (enum stored in either this or another script using the touchpad)
            tempLine = Instantiate(new GameObject("line"), startTransf.position, startTransf.rotation);
            lineRend = tempLine.AddComponent<LineRenderer>();
            lineRend.SetPosition(curPosIndex, startTransf.position);
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

    public void StopDraw() {
        //on stop pressing trigger
        //judge line and instantiate effect
        myState = LineState.Clean;
    }
}
