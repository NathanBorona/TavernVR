using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


namespace VRTK {
    public class OrientationLineJudge : MonoBehaviour {
        public MagicHealth playerHealth;
        //Script for drawing and judging magic lines WIP.
        //I may reconsider this script and put it on the lines instead. still trying to think of way to make this work.
        int spellType;
        enum LineState { Start, Draw, Stop, Clean };
        LineState myState;
        //Enum for switch statement. states of drawing - start, draw, and clean. judge state is defined by trigger end event.
        float redAm;
        float blueAm;
        float greenAm;
        Color oldCol;
        Color tarCol;
        Color realCol;
        float colorLerpTime;
        bool roundStart = true;
        public GameObject shieldSpell;
        public GameObject boltSpell;

        public Renderer crystalMaterial;
        float ogValue;

        Vector3 lineStPos;
        Vector3 lineEnPos;
        public float maxDrawDist;
        int curPosIndex;
        public LineRenderer lineRend;
        Transform startTransf;
        Transform currentTransf;
        bool startAllowed;
        float dotLineAngle;

        public VRTK_ControllerEvents myController;

        void Awake() {
            AssignVariablesMisc();
            myState = LineState.Start;
        }

        void Start() {
            playerHealth.curHealth = 0;
        }

        void AssignVariablesMisc() {
            /*personal preference: I like to define all of my misc variables in a 
            collapsable function so they're not in the way if I'm looking for something in code.*/
            lineStPos = Vector3.zero;
            lineEnPos = Vector3.zero;
            curPosIndex = 0; //makes sure the current index position for drawing lines is set to 0 at the start.
            lineStPos = Vector3.zero;
            lineEnPos = Vector3.zero;
            lineRend.positionCount = 0;
            ogValue = crystalMaterial.material.color.a;
            oldCol = Color.white;
            tarCol = Color.white;
        }

        void Update() {
            if (myController != null && myController.gripPressed) {
                GetComponent<NoDropInteractable>().ForceStopRound();
                roundStart = true;
            }
            if (playerHealth != null && playerHealth.curHealth <= 0 && !roundStart) {
                GetComponent<NoDropInteractable>().ForceStopRound();
                roundStart = true;
            }
            if (myController != null) {
                if (roundStart) {
                    playerHealth.curHealth = playerHealth.maxHealth;
                    PlayerPrefs.SetInt("Score", 0);
                    roundStart = false;
                }
                switch (myState) {
                    case LineState.Start:
                            StartLine();
                            CheckColor();
                        break;
                    case LineState.Draw:
                        currentTransf = myController.transform;
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
        }

        void ColorLerpDEBUG() {
            if (Input.GetKeyDown(KeyCode.Keypad1)) { // for debugging RED
                redAm = 1f;
                greenAm = 0.25f;
                blueAm = 0.25f;
                tarCol = new Color(redAm, greenAm, blueAm);
                oldCol = crystalMaterial.material.color;
                colorLerpTime = 0f;
                spellType = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)) { // for debugging GREEN
                redAm = 0.25f;
                greenAm = 1f;
                blueAm = 0.25f;
                tarCol = new Color(redAm, greenAm, blueAm);
                oldCol = crystalMaterial.material.color;
                colorLerpTime = 0f;
                spellType = 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3)) { // for debugging BLUE
                redAm = 0.25f;
                greenAm = 0.25f;
                blueAm = 1f;
                tarCol = new Color(redAm, greenAm, blueAm);
                oldCol = crystalMaterial.material.color;
                colorLerpTime = 0f;
                spellType = 2;
            }
        }

        void CheckColor() {
            if (colorLerpTime >= 1f) {
                oldCol = crystalMaterial.material.color;
                colorLerpTime = 0f;
            }
            ColorLerpDEBUG(); //ONLY RUN THIS IF USING VRTK SIMULATOR. Num1, 2, 3 change colors;

            //SPELL TYPES: 0 = red, 1 = green, 2 = blue.
            if (myController.touchpadAxisChanged) {
                float myAngle = myController.GetTouchpadAxisAngle();
                {/*if (myController.GetTouchpadAxisAngle() <= 90 && myController.GetTouchpadAxisAngle() > 45) {
                    //if in the center of the red and green tri
                    if (myController.GetTouchpadAxis().x > 0) {
                        redAm = 1f;
                        spellType = 0;
                    }
                    else {
                        greenAm = 1f;
                        spellType = 1;
                    }
                }
                else if (myController.GetTouchpadAxisAngle() > 90 && myController.GetTouchpadAxisAngle() < 120) {
                    if (myController.GetTouchpadAxis().x > 0) {
                        //if in the half of the red and green tri
                        redAm = 0.5f;
                        greenAm = 0.25f;
                        spellType = 0;
                    }
                    redAm = 0.25f;
                    greenAm = 0.5f;
                    spellType = 1;
                }
                if (myController.GetTouchpadAxisAngle() >= 120 && myController.GetTouchpadAxisAngle() < 150) {
                    blueAm = 0.5f;
                    spellType = 2;
                    //if in the first half of the blue tri
                }
                else if (myController.GetTouchpadAxisAngle() >= 150) {
                    blueAm = 1f;
                    //else if in the center of the blue tri
                    spellType = 2;
                }
                else {
                    blueAm = 0.25f;
                    //else if outside of blue
                }*/

                    //detect if red
                    //detect if green
                    //detect if blue
                }
                if (myAngle >= 0 && myAngle < 120) {
                    tarCol = Color.red;
                    spellType = 0;
                }
                if (myAngle >= 120 && myAngle < 240) {
                    tarCol = Color.green;
                    spellType = 1;

                }
                if (myAngle >= 240) {
                    tarCol = Color.blue;
                    spellType = 2;

                }
                tarCol.a = ogValue;
                oldCol = crystalMaterial.material.color;
            }

            if (oldCol != tarCol) {
                realCol = Color.Lerp(oldCol, tarCol, colorLerpTime);// this doesn't work because it's setting it to a value between 0 and 1.
                colorLerpTime += 0.02f;
                
            } // I want to put this in update, and not use oldCol as a method of judgement.

            if (myController.touchpadPressed) {
                if (myController.GetTouchpadAxisAngle() <= 120) {
                    if (myController.GetTouchpadAxis().x > 0) {
                        realCol = new Color(1f, 0.25f, 0.25f, ogValue);
                    }
                    else {
                        realCol = new Color(0.25f, 1f, 0.25f, ogValue);
                    }
                }
                else {
                    realCol = new Color(0.25f, 0.25f, 1f, ogValue);
                }
            }
            crystalMaterial.material.color = realCol;
        }

        void CleanUp() {
            //resets all changed variables to what they were at the start.
            lineRend.positionCount = 0;
            curPosIndex = 0;
            startAllowed = true;
            dotLineAngle = 0f;
            myState = LineState.Start;

        }

        void StartLine() { //TO BE USED on trigger press stay event
                if (myController.triggerPressed) {
                    startTransf = myController.transform;
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
            if (myController.triggerPressed) {
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
            //Debug.Log(lineRend.positionCount);
            if (lineRend.positionCount >= 3) {
                //on stop pressing trigger
                //judge line and instantiate effect
                lineEnPos = lineRend.GetPosition(lineRend.positionCount - 1);
                lineStPos = lineRend.GetPosition(0);
                Vector3 normLine = lineEnPos - lineStPos;
                Vector3 midLine = lineRend.GetPosition(Mathf.RoundToInt(lineRend.positionCount * 0.5f));
                dotLineAngle = Vector3.Angle(Vector3.up, normLine);

                if (dotLineAngle >= 90f - 22.5f && dotLineAngle <= 90f + 22.5f) {
                    //is horizontal spell
                    Debug.Log("cast horizontal spell");

                    GameObject newSpell = Instantiate(shieldSpell, midLine, Quaternion.identity);
                    newSpell.GetComponent<SpellShield>().elementType = spellType;
                }
                else if (dotLineAngle > 135f - 22.5f && dotLineAngle < 135f + 22.5f) {
                    //is diagonal spell

                    Debug.Log("cast diagonal spell");
                }
                else {
                    //is vertical spell
                    Debug.Log("cast vertical spell");
                    GameObject newSpell = Instantiate(boltSpell, midLine, Quaternion.identity);
                    newSpell.GetComponent<SpellBall>().elementType = spellType;

                }
            }
            myState = LineState.Clean;
        }
    }
}
