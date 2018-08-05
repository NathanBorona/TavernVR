using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellBall : SpellScript {
        public int elementType;
        GameObject trueTarget;
        Rigidbody spellRB;
        public float speedMult;

        protected override void SetSpellState() {
            curSpell = MySpellState.Bolt;
        }
        public override void OnSpellUngrab() {
            curCast = MyCastState.Thrown;
        }
        protected override void SpellCast() {
            //use targetEnemy as target
            //send ball towards target enemy. no gravity, and correct for overshooting
            spellRB.AddForce(spellRB.mass * speedMult * Vector3.Normalize(targetEnemy.transform.position - transform.position));
        }

    }
}
