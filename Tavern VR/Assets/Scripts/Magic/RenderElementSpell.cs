using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class RenderElementSpell : MonoBehaviour {
        enum MySpellType { bolt, shield };
        MySpellType thisSpell;
        SpellBall myBolt;
        SpellShield myShield;
        int myElement;
        public GameObject[] myRenderElements;
        //MAKE SURE THESE ARE IN THE SAME ORDER AS THE myElement Int list
        //0 = Fire, 1 = Thorns, 2 = Water.

        private void Awake() {
            if (GetComponentInParent<SpellBall>() != null) {
                myBolt = GetComponentInParent<SpellBall>();
                myElement = myBolt.elementType;
                thisSpell = MySpellType.bolt;
            }
            if (GetComponentInParent<SpellShield>() != null) {
                myShield = GetComponentInParent<SpellShield>();
                myElement = myShield.elementType;
                thisSpell = MySpellType.shield;
            }
            ChangeElement();
        }

        private void Update() {
            switch (thisSpell) {
                case (MySpellType.bolt):
                    //if this spell is a bolt
                    if (myElement != myBolt.elementType) {
                        //and if it's element is not the bolt's element
                        myElement = myBolt.elementType;
                        //set this object's element to it's bolt's element
                        ChangeElement();
                        //and changeelement
                    }
                    break;
                case (MySpellType.shield):
                    if (myElement != myShield.elementType) {
                        myElement = myShield.elementType;
                        ChangeElement();
                    }
                    break;
            }
        }

        private void ChangeElement() {
            //changes element to the chosen element, disables all elements that aren't the bolt's element
            for (int i = 0; i < myRenderElements.Length; i++) {
                //for each of the spell renders under this,
                if (i != myElement) {
                    myRenderElements[i].SetActive(false);
                    //if the number representing the element is not my element, set it to false
                }
                else {
                    myRenderElements[i].SetActive(true);
                    //else set to true
                }
            }
        }
    }
}
