using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpellSlinger : MonoBehaviour {
    //need a timer
    GameObject myCastSpell;
    int mySpellType;
    int myElement;
    Animator myAnimator;

    enum MyState { Cast, Throw };
    MyState myState = MyState.Cast;

    //randomly decide a spell (int 0, 1)
    //randomly decide a color (int 0, 1, 2)
    //use animator controller to set states.
    //on "casting" state, instantiate spell and "grab" it
    //on "throwing" state, start the animation that uses the function below

    private void Update() {
        switch (myState) {
            case (MyState.Cast):

                break;
            case (MyState.Throw):
                UngrabAIAnimFunct();
                break;
        }
    }
    public void UngrabAIAnimFunct() {
        //reference script in instantiated spell
    }
}
