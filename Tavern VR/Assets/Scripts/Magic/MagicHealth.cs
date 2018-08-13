using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class MagicHealth : MonoBehaviour {
        public int maxHealth;
        int curHealth;

        private void Start() {
            curHealth = maxHealth;
        }

        public void Damage(int d) {
            curHealth -= d;
            if (curHealth <= 0) {
                ThisDeath();
            }
        }

        public void ThisDeath() {
            //any instantiated effects

            Destroy(gameObject);
        }
    }
}
