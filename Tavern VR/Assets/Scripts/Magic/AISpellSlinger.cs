using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class AISpellSlinger : MonoBehaviour {
        public bool AIENABLED;
        float timer;
        SpellScript mySpellScript;
        public GameObject boltSpell;
        public float spellCooldown;
        public GameObject[] hands;
        GameObject myCastLoc;
        GameObject myCastSpell;
        int mySpellType;
        int myElement;
        Animator myAnimator;
        bool isHoldingSpell = false;

        enum MyState { Cast, Throw };
        MyState myState = MyState.Cast;

        private void Start() {
            timer = 0f;
        }

        //randomly decide a spell (int 0, 1)
        //randomly decide a color (int 0, 1, 2)
        //use animator controller to set states.
        //on "casting" state, instantiate spell and "grab" it
        //on "throwing" state, start the animation that uses the function below

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha0)) {
                AIENABLED = !AIENABLED;
            }
            if (isHoldingSpell) {
                myCastSpell.transform.position = myCastLoc.transform.position;
            }
            switch (myState) {
                case (MyState.Cast):
                    if (AIENABLED == true)
                    timer += Time.deltaTime;
                    if (timer >= spellCooldown) {
                        ChooseCastingHand();
                    }
                    break;
                case (MyState.Throw):
                    myAnimator = myCastLoc.GetComponent<Animator>();
                    myAnimator.SetTrigger("Throw");
                    break;
            }
        }

        void ChooseCastingHand() {
            timer = 0f;
            myCastLoc = hands[Random.Range(0, hands.Length)];
            myCastSpell = Instantiate(boltSpell, myCastLoc.transform.position, myCastLoc.transform.rotation);
            mySpellScript = myCastSpell.GetComponent<SpellScript>();
            mySpellScript.elementType = myElement;
            mySpellScript.OnSpellGrab();
            isHoldingSpell = true;
            myState = MyState.Throw;
        }

        public void UngrabAIAnimFunct() {
            isHoldingSpell = false;
            mySpellScript.OnSpellUngrab();
        }
    }
}