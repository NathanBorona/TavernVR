using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


namespace VRTK {
    public class OrientationLineJudge : MonoBehaviour {
        //Script for drawing and judging magic lines WIP.
        //I may reconsider this script and put it on the lines instead. still trying to think of way to make this work.

        enum LineState { Start, Draw, Stop, Clean };
        LineState myState;
        //Enum for switch statement. states of drawing - start, draw, and clean. judge state is defined by trigger end event.
        float redAm;
        float blueAm;
        float greenAm;
        Color oldCol;
        Color curCol;
        Color realCol;
        public float lerpCol;

        Vector3 lineStPos;
        Vector3 lineEnPos;
        public float maxDrawDist;
        int curPosIndex;
        public LineRenderer lineRend;
        Transform startTransf;
        Transform currentTransf;
        bool startAllowed;
        float dotLineAngle;

        public VRTK_ControllerEvents myRightController;
        public VRTK_ControllerEvents myLeftController;

        void Awake() {
            AssignVariablesMisc();
            myState = LineState.Start;
        }

        void AssignVariablesMisc() {
            /*personal preference: I like to define all of my misc variables in a 
            collapsable function so they're not in the way if I'm looking for something in code.*/
            lineStPos = Vector3.zero;
            lineEnPos = Vector3.zero;
            curPosIndex = 0; //makes sure the current index position for drawing lines is set to 0 at the start.
            myRightController = GameObject.FindGameObjectWithTag("RightController").GetComponent<VRTK_ControllerEvents>();
            myLeftController = GameObject.FindGameObjectWithTag("LeftController").GetComponent<VRTK_ControllerEvents>();
            lineStPos = Vector3.zero;
            lineEnPos = Vector3.zero;
            lineRend.positionCount = 0;
        }

        void Update() {
            switch (myState) {
                case LineState.Start:
                    StartLine();
                    CheckColor();
                    break;
                case LineState.Draw:
                    currentTransf = myLeftController.transform;
                    DrawLine();
                    break;
                case LineState.Stop:
                    StopDraw();
                    break;
                case LineState.Clean:
                    CleanUp();
                    startTransf = transform;
                    currentTransf = transform;
                    break;
            }
        }

        void CheckColor() {
            oldCol = curCol;
            if (myLeftController.touchpadAxisChanged) {
                if (myLeftController.GetTouchpadAxisAngle() <= 90 && myLeftController.GetTouchpadAxisAngle() > 45) {
                    //if in the center of the red and green tri
                    if (myLeftController.GetTouchpadAxis().x > 0) {
                        redAm = 1f;
                    }
                    else {
                        greenAm = 1f;
                    }
                }
                else if (myLeftController.GetTouchpadAxisAngle() > 90 && myLeftController.GetTouchpadAxisAngle() < 120) {
                    if (myLeftController.GetTouchpadAxis().x > 0) {
                        redAm = 0.5f;
                        greenAm = 0.25f;
                    }
                    redAm = 0.25f;
                    greenAm = 0.5f;
                }

                if (myLeftController.GetTouchpadAxisAngle() >= 120 && myLeftController.GetTouchpadAxisAngle() < 150) {
                    blueAm = 0.5f;
                    //if in the first half of the blue tri
                }
                else if (myLeftController.GetTouchpadAxisAngle() >= 150) {
                    blueAm = 1f;
                    //else if in the center of the blue tri
                }
                else {
                    blueAm = 0.25f;
                    //else if outside of blue
                }
                curCol = new Color(redAm, greenAm, blueAm);
                if (oldCol != curCol) {
                    realCol = Color.Lerp(oldCol, curCol, lerpCol);
                    //crystalFocus.Color = realCol;
                }
            }
            if (myLeftController.touchpadPressed) {
                if (myLeftController.GetTouchpadAxisAngle() <= 120) {
                    if (myLeftController.GetTouchpadAxis().x > 0) {
                        //red
                    }
                    else {
                        //green
                    }
                }
                else {
                    //blue
                }
            }
        }

        void CleanUp() {
            //resets all changed variables to what they were at the start.
            lineRend.positionCount = 0;
            curPosIndex = 0;
            startAllowed = true;
            myState = LineState.Start;

        }

        void StartLine() { //TO BE USED on trigger press stay event
            if (myLeftController.triggerPressed) {
                startTransf = myLeftController.transform;
                //when the crystal is used - how do I do the thing where you check if trigger is pressed/recieve events from VRTK?
                //get the current color (enum stored in either this or another script using the touchpad)
                lineRend.positionCount = lineRend.positionCount + 1;
                lineRend.SetPosition(0, startTransf.position);
                //sets the first point of the line to the same position as the controller
                curPosIndex++;
                myState = LineState.Draw;
            }
        }

        void DrawLine() {
            if (myLeftController.triggerPressed) {
                if (Vector3.Distance(currentTransf.position, lineRend.GetPosition(lineRend.positionCount-1)) > maxDrawDist) {
                    lineRend.positionCount = lineRend.positionCount + 1;
                    lineRend.SetPosition(lineRend.positionCount-1, currentTransf.position);
                    //curPosIndex++;                   
                    //Debug.Log(lineRend.positionCount);
                }
            }
            else {
                myState = LineState.Stop;
            }
        }



        void StopDraw() {
            //on stop pressing trigger
            //judge line and instantiate effect
            lineEnPos = lineRend.GetPosition(lineRend.positionCount - 1);
            lineStPos = lineRend.GetPosition(0);
            Vector3 normLine = lineEnPos - lineStPos;
            dotLineAngle = Vector3.Angle(Vector3.up, normLine);

            if (dotLineAngle >= 90f-22.5f && dotLineAngle <= 90f+22.5f) {
                //is horizontal spell
                Debug.Log("cast horizontal spell");
            } else if (dotLineAngle > 135f-22.5f && dotLineAngle < 135f + 22.5f) {
                //is diagonal spell
                Debug.Log("cast diagonal spell");
            } else {
                //is vertical spell
                Debug.Log("cast vertical spell");
            }
            myState = LineState.Clean;
        }
    }
}
