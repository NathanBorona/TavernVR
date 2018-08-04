using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class SpellInteractable : VRTK_InteractableObject {
        SpellScript mySpellScript;
        GameObject grabbingObj;

            public override void OnInteractableObjectGrabbed(InteractableObjectEventArgs e) {
            base.OnInteractableObjectGrabbed(e);
            grabbingObj = grabbingObjects[0];
            mySpellScript = GetComponent<SpellScript>();
            mySpellScript.myController = grabbingObj.GetComponent<VRTK_ControllerEvents>();
            mySpellScript.caster = Camera.main.gameObject;
        }
        public override void OnInteractableObjectUngrabbed(InteractableObjectEventArgs e) {
            base.OnInteractableObjectUngrabbed(e);
            mySpellScript.OnSpellUngrab();
        }

    }
}
