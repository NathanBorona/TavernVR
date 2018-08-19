using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class MagicHealth : MonoBehaviour {
        public bool isPlayer = false;
        AISpellSlinger myAI;
        public int maxHealth;
        public int curHealth;

        private void Start() {
            if (!isPlayer) {
                myAI = GetComponent<AISpellSlinger>();
            }
            curHealth = maxHealth;
        }

        public void Damage(int d, GameObject whatHitMe) {
            //Debug.Log("OH MY GOD SO MANY OF THESE OH NO" + whatHitMe.name);
            curHealth = curHealth - d;
            if (curHealth <= 0) {
                ThisDeath();
            }
        }

        public void ThisDeath() {
            if (!isPlayer) {
                if (myAI.spellCooldown > 0.5f) {
                    myAI.spellCooldown -= 0.25f;
                }
                //add a thing here to increase score
                curHealth = maxHealth;
            }
            //add player death effects here
        }
    }
}