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
                    if (myElement != myBolt.elementType) {
                        myElement = myBolt.elementType;
                        ChangeElement();
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

            for (int i = 0; i < myRenderElements.Length; i++) {
                if (i != myElement) {
                    myRenderElements[i].SetActive(false);
                }
                else {
                    myRenderElements[i].SetActive(true);
                }
            }
        }
    }
}
