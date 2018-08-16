using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class HealthParse : MonoBehaviour {
        public MagicHealth myPlayerHealth;
        public int health;
        public int maxHealth;
        private void Start() {
            maxHealth = myPlayerHealth.maxHealth;
        }

        // Update is called once per frame
        void Update() {
            health = myPlayerHealth.curHealth;
        }
    }
}