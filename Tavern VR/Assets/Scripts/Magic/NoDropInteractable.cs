﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class NoDropInteractable : VRTK_InteractableObject {
        //VRTK_InteractGrab controllerGrabbing;
        GameObject grabbingObj;
        OrientationLineJudge myLineJudge;
        /*protected override void FixedUpdate() {
            base.FixedUpdate();
        }*/

        //bool hasBeenGrabbed;
        public override void OnInteractableObjectGrabbed(InteractableObjectEventArgs e) {
            base.OnInteractableObjectGrabbed(e);
            //hasBeenGrabbed = true;
            //controllerGrabbing = grabbingObjects[0].GetComponent<VRTK_InteractGrab>();
            grabbingObj = grabbingObjects[0];
            myLineJudge = GetComponent<OrientationLineJudge>();
            myLineJudge.myController = grabbingObj.GetComponent<VRTK_ControllerEvents>();
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++) {
                GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<AISpellSlinger>().AIENABLED = true;
            }
        }

        private void Start() {
            originalDroppable = droppable;
            droppableAlt = droppable;
        }

        public bool droppable;
        bool droppableAlt;
        bool originalDroppable;

        public void ForceStopRound() {
            droppable = true;
            droppableAlt = droppable;
            Ungrabbed();
            myLineJudge.myController = null;
        }

        protected override void PrimaryControllerUngrab(GameObject previousGrabbingObject, GameObject previousSecondaryGrabbingObject) {
            UnpauseCollisions();
            RemoveTrackPoint();
            ResetUseState(previousGrabbingObject);
            grabbingObjects.Clear();
            if (secondaryGrabActionScript != null && previousSecondaryGrabbingObject != null) {
                secondaryGrabActionScript.OnDropAction();
                previousSecondaryGrabbingObject.GetComponent<VRTK_InteractGrab>().ForceRelease();
            }
            LoadPreviousState();
        }
        protected override void SecondaryControllerUngrab(GameObject previousGrabbingObject) {
            if (grabbingObjects.Contains(previousGrabbingObject)) {
                grabbingObjects.Remove(previousGrabbingObject);
                if (droppable) {
                    Destroy(secondaryControllerAttachPoint.gameObject);
                }
                secondaryControllerAttachPoint = null;
                if (secondaryGrabActionScript != null) {
                    secondaryGrabActionScript.ResetAction();
                }
            }
        }
        public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null) {
            if (droppable) {
                myLineJudge.myController = null;
                droppable = originalDroppable;
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++) {
                    GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<AISpellSlinger>().AIENABLED = false;
                }
                base.Ungrabbed(previousGrabbingObject);
            }
        }
    }
}
