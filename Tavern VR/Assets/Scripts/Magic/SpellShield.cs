using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellShield : SpellScript {
        public float speedMult;

        private void Awake() {
            spellRB = GetComponent<Rigidbody>();
        }

        protected override void SetSpellState() {
            curSpell = MySpellState.Bolt;
        }
        public override void OnSpellGrab() {
            base.OnSpellGrab();
            curCast = MyCastState.Thrown;
        }
        public override void OnSpellUngrab()
        {
            base.OnSpellUngrab();
            Destroy(gameObject);
        }
        protected override void SpellCast() {
            
        }
        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.GetComponent<SpellBall>() != null) {
                SpellBall otherBolt = collision.gameObject.GetComponent<SpellBall>();
                //SPELL TYPES: 0 = red, 1 = green, 2 = blue. 0 reflects 1, 1 reflects 2, 2 reflects 0.
                if (elementType + 1 == otherBolt.elementType || elementType - 2 == otherBolt.elementType) {
                    otherBolt.targetEnemy = targetEnemy;
                    otherBolt.damage = Mathf.RoundToInt(otherBolt.damage * 1.5f);
                    otherBolt.elementType = elementType;
                }
                if (elementType - 1 == otherBolt.elementType || elementType + 2 == otherBolt.elementType) {
                    otherBolt.damage = otherBolt.damage * 2;
                    Destroy(gameObject);
                }
                else {
                    Destroy(otherBolt.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}