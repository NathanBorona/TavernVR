using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class AnimationEventParse : MonoBehaviour {
        [HideInInspector]
        public AISpellSlinger myParent;

        public void EventParse() {
            myParent.UngrabAIAnimFunct();
        }
    }
}
