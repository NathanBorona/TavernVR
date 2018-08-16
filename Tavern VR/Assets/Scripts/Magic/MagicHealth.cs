using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class MagicHealth : MonoBehaviour {
        public bool isPlayer = false;
        public int maxHealth;
        public int curHealth;

        private void Start() {
            curHealth = maxHealth;
        }

        public void Damage(int d, GameObject whatHitMe) {
            Debug.Log("OH MY GOD SO MANY OF THESE OH NO" + whatHitMe.name);
            curHealth = curHealth - d;
            if (curHealth <= 0) {
                ThisDeath();
            }
        }

        public void ThisDeath() {
            //any instantiated effects
            if (!isPlayer) {
                gameObject.GetComponent<AISpellSlinger>().spellCooldown -= 1f;
                curHealth = maxHealth;
            }
        }
    }
}