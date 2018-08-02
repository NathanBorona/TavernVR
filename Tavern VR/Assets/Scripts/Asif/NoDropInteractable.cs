using System.Collections;
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
        }


        //THIS DOWNWARD IS REQUIRED FOR NON DROPPABLE:
        //(with a few exceptions)

        private void Start() {
            originalDroppable = droppable;
        }

        public bool droppable;
        bool originalDroppable;

        public void ForceStopRound() {
            droppable = true;
            Ungrabbed();
            //not needed
            myLineJudge.myController = null;
            //not needed
        }

        public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null) {
            if (droppable) {
                //not needed
                myLineJudge.myController = null;
                //not needed
                droppable = originalDroppable;
                base.Ungrabbed(previousGrabbingObject);
            }
        }
    }
}
