using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class AnimationEventParse : MonoBehaviour {
        AISpellSlinger myParent;
        private void Start() {
            myParent = GetComponentInParent<AISpellSlinger>();
        }
        public void EventParse() {
            myParent.UngrabAIAnimFunct();
        }
    }
}
