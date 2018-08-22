using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK {
    public class MagicHealth : MonoBehaviour {
        public bool isPlayer = false;
        AISpellSlinger myAI;
        public int maxHealth;
        public int curHealth;
        int scoreBonus;
        private void Start() {
            if (!isPlayer) {
                scoreBonus = maxHealth;
                myAI = GetComponent<AISpellSlinger>();
                curHealth = maxHealth;
            }
            if (!PlayerPrefs.HasKey("CurrentTurn")) {
                PlayerPrefs.SetInt("CurrentTurn", 0);
            }

        }

        public void Damage(int d, GameObject whatHitMe) {
            //Debug.Log("OH MY GOD SO MANY OF THESE OH NO" + whatHitMe.name);
            curHealth = curHealth - d;
            if (scoreBonus != 0) {
                scoreBonus -= 1;
            }
            if (curHealth <= 0) {
                ThisDeath();
                scoreBonus = maxHealth;
            }
        }

        public void ThisDeath() {
            if (!isPlayer) {
                if (myAI.spellCooldown > 0.5f) {
                    myAI.spellCooldown -= 0.25f;
                }
                for (int i = 0; i < 15; i++) {
                    if (!PlayerPrefs.HasKey("MageScore" + i)) {
                        PlayerPrefs.SetInt("MageScore" + i, 0);
                    }
                    if (PlayerPrefs.GetInt("CurrentTurn") == 15) {
                        PlayerPrefs.SetInt("CurrentTurn", 0);
                        SlideScores();
                    }
                }
                PlayerPrefs.SetInt("MageScore" + (PlayerPrefs.GetInt("CurrentTurn")), PlayerPrefs.GetInt("MageScore" + (PlayerPrefs.GetInt("CurrentTurn"))) + (maxHealth*scoreBonus));
                PlayerPrefs.Save();
                curHealth = maxHealth;
            }

            PlayerPrefs.SetInt("CurrentTurn", PlayerPrefs.GetInt("CurrentTurn") + 1);
            PlayerPrefs.Save();
        }

        void SlideScores() {
            int[] tempInt = new int[15];
            for (int i = 0; i < 15; i++) {
                tempInt[i] = PlayerPrefs.GetInt("MageScore" + i);
            }
            for (int i = 0; i < tempInt.Length; i++) {
                if (i != 14) {
                    PlayerPrefs.SetInt("MageScore" + (i + 1), tempInt[i]);
                }
            }
            PlayerPrefs.SetInt("MageScore" + 0, 0);
        }
    }
}