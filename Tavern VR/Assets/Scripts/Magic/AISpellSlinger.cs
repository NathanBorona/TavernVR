using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class AISpellSlinger : MonoBehaviour {
        AnimationEventParse myHandScript;
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
            spellCooldown = Mathf.Clamp(spellCooldown, 1f, 30f);
            if (Input.GetKeyDown(KeyCode.Alpha0)) {
                AIENABLED = !AIENABLED;
            }
            if (AIENABLED == true) {
                if (isHoldingSpell) {
                    myCastSpell.transform.position = myCastLoc.transform.position;
                }
                switch (myState) {
                    case (MyState.Cast):
                        timer += Time.deltaTime;
                        if (timer >= 0.5 * spellCooldown && !isHoldingSpell) {
                            myElement = Random.Range(0, 3);
                            ChooseCastingHand();
                        }
                        if (timer >= spellCooldown) {
                            timer = 0f;
                            myState = MyState.Throw;
                        }
                        break;
                    case (MyState.Throw):
                        myAnimator = myCastLoc.GetComponent<Animator>();
                        myAnimator.SetTrigger("CastSpell");
                        myState = MyState.Cast;
                        break;
                }
            }
        }

        void ChooseCastingHand() {
            myCastLoc = hands[Random.Range(0, hands.Length)];
            myHandScript = myCastLoc.GetComponent<AnimationEventParse>();
            myHandScript.myParent = this;
            myCastSpell = Instantiate(boltSpell, myCastLoc.transform.position, myCastLoc.transform.rotation);
            mySpellScript = myCastSpell.GetComponent<SpellScript>();
            mySpellScript.elementType = myElement;
            mySpellScript.OnSpellGrabNPC(gameObject);
            isHoldingSpell = true;
        }

        public void UngrabAIAnimFunct() {
            isHoldingSpell = false;
            mySpellScript.OnSpellUngrab();
        }
    }
}