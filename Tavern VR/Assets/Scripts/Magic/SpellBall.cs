﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellBall : SpellScript {
        public int damage = 1;
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
                    if (spellRB.velocity.sqrMagnitude <= 0.05f) {
                        hasStopped = true;
                    }
                }
                else {
                    spellRB.AddForce(spellRB.mass * 0.5f * -spellRB.velocity);
                    if (spellRB.velocity.sqrMagnitude < 50f)
                    spellRB.AddForce(spellRB.mass * speedMult * Vector3.Normalize(targetEnemy.transform.position - transform.position));
                }
                //use targetEnemy as target
                //send ball towards target enemy. no gravity, and correct for overshooting
            }
        }
        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject == targetEnemy && collision.gameObject.GetComponent<MagicHealth>() != null) {
                collision.gameObject.GetComponent<MagicHealth>().Damage(damage,this.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
