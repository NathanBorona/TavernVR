using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellBall : SpellScript {
        public int elementType;
        Rigidbody spellRB;
        public float speedMult;

        private void Awake() {
            spellRB = GetComponent<Rigidbody>();
        }

        protected override void SetSpellState() {
            curSpell = MySpellState.Bolt;
        }
        public override void OnSpellUngrab() {
            base.OnSpellUngrab();
            curCast = MyCastState.Thrown;
        }
        protected override void SpellCast() {
            if (targetEnemy != null) {
                //use targetEnemy as target
                //send ball towards target enemy. no gravity, and correct for overshooting
                spellRB.AddForce(spellRB.mass * speedMult * Vector3.Normalize(targetEnemy.transform.position - transform.position));
                spellRB.AddForce(spellRB.mass * 0.5f * -spellRB.velocity);
            }
        }
        private void OnCollisionEnter(Collision collision) {
            //if (collision.gameObject.GetComponent<SpellShield>() != null) {

            //}
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") {

            }
        }

    }
}
