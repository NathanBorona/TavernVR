using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellScript : MonoBehaviour {
        public VRTK_ControllerEvents myController;
        protected enum MyCastState { Held, Thrown, Idle };
        protected MyCastState curCast = MyCastState.Idle;
        protected enum MySpellState { Bolt, Shield, Default };
        protected MySpellState curSpell;
        protected GameObject targetEnemy;
        protected GameObject[] enemies;
        public GameObject caster;
        protected Vector3[] enemyPositions;

        protected virtual void SetSpellState() {
            curSpell = MySpellState.Default;
            //overriden by their spells to set the state for debugging.
        }

        protected virtual void Start() {
            SetSpellState();
            FindEnemies();
        }

        protected virtual void FindEnemies() {
            //either gets a list of all tagged enemies or a list of all enemies minus the caster (for AI casting)
            if (caster == Camera.main.gameObject) {
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
            }

            else {
                GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
                List<GameObject> allTargets = new List<GameObject>();
                for (int i = 0; i < targets.Length; i++) {
                    allTargets.Add(targets[i]);
                }
                allTargets.Remove(caster);
                allTargets.Add(Camera.main.gameObject);
                enemies = new GameObject[allTargets.Count];
                for (int t = 0; t < enemies.Length; t++) {
                    enemies[t] = allTargets[t];
                }
            }
        }

        protected virtual void Update() {
            switch (curCast) {
                case MyCastState.Idle:
                    //idlestuff
                    break;
                case MyCastState.Held:
                    TargetFind();
                    break;
                case MyCastState.Thrown:
                    SpellCast();
                    break;
            }
        }

        protected virtual void TargetFind() {
            if (caster == Camera.main.gameObject) {
                //if caster is player, targets enemy closest to center of screen
                float myDist = 0f;
                Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
                for (int i = 0; i < enemies.Length; i++) {
                    if (Camera.main.WorldToScreenPoint(enemies[i].transform.position) != null) {
                        enemyPositions[i] = Camera.main.WorldToScreenPoint(enemies[i].transform.position);
                    }
                    enemyPositions[i] = new Vector3(enemyPositions[i].x, enemyPositions[i].y, 0f);
                    if (targetEnemy != null) {
                        if (Vector3.Distance(enemyPositions[i], screenCenter) < myDist) {
                            myDist = Vector3.Distance(enemyPositions[i], screenCenter);
                            targetEnemy = enemies[i];
                        }
                    }
                    else {
                        targetEnemy = enemies[i];
                        myDist = Vector3.Distance(enemyPositions[i], screenCenter);
                    }
                }
            }
            else {
                //AI targets random from list
                targetEnemy = enemies[Random.Range(0, enemies.Length)];
            }
        }

        protected virtual void SpellCast() {
            Debug.LogError(curSpell + " has cast but is not overriding. Despite setting state, other Scripts seem to be missing or are throwing errors.");
        }

        public virtual void OnSpellUngrab() {
            //use TargetFind to set a static target for the spell
        }

        public virtual void OnSpellGrab() {
            curCast = MyCastState.Held;
        }


        /*WIP: things needed for all spells:
         * activate on stop grab - not sure how, but it's possible
         * Instantiate from OrientationLineJudge
         * 
         * In short:
         * Target variable
         * Caster variable
         * Checker to see if ungrabbed
        */

        /*WIP: things needed for ball spell:
         * public class SpellBall : SpellScript {}
         * target heat seeking
         * 
         * AI: throw ball of color
        */

        /*WIP: things needed for shield spell:
         * shield reflects back at target if correct colour
         * 
         * AI: React to other thrown ball by drawing shield - of whatever colour currently selected. Need states.
        */
    }
}
