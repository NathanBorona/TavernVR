using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellBall : SpellScript {
        public int damage = 10;
        public float speedMult;
        bool hasStopped = false;

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
                if (!hasStopped) {
                    spellRB.AddForce(spellRB.mass * -spellRB.velocity);
                    if (spellRB.velocity.sqrMagnitude <= 0.25f) {
                        hasStopped = true;
                    }
                }
                else {
                    spellRB.AddForce(spellRB.mass * speedMult * Vector3.Normalize(targetEnemy.transform.position - transform.position));
                }
                //use targetEnemy as target
                //send ball towards target enemy. no gravity, and correct for overshooting
            }
        }
        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject == targetEnemy) {
                //health script needed for all characters in scene
            }
        }
    }
}
