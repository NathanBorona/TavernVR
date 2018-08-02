using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class NoDropInteractable : VRTK_InteractableObject {
        public bool droppable;
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
        }

        public void ForceStopRound() {
            this.ForceReleaseGrab();
            myLineJudge.myController = null;

        }
        public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null) {
            if (droppable) {
                base.Ungrabbed(previousGrabbingObject);
                myLineJudge.myController = null;
            }
        }
    }
}
