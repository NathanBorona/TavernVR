using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class OrientationLineJudge : MonoBehaviour {
    enum LineState {Start, Draw, Clean};
    LineState myState;

    public float maxDrawDist;

    int curPosIndex;
    GameObject tempLine;
    LineRenderer lineRend;

    Transform startTransf;
    Transform currentTransf;
    void Awake () {
        myState = LineState.Start;
        curPosIndex = 0;
	}
	
	void Update () {
        switch (myState) {
            case LineState.Start:
                startTransf = transform; //but actually please use the controller's transform
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
        myState = LineState.Start;
    }

    public void StartLine() {
        //when the crystal is used 
        //get the current color (enum stored in either this or another script using the touchpad)
        //get the facing of the crystal/controller using startTransf
        tempLine = Instantiate(new GameObject("line"), startTransf.position, Quaternion.identity);
        lineRend = tempLine.AddComponent<LineRenderer>();
        lineRend.SetPosition(curPosIndex, startTransf.position);
        curPosIndex++;
        myState = LineState.Draw;
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
