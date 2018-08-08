using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK {
    public class SpellScript : MonoBehaviour {
        protected Rigidbody spellRB;
        public int elementType;
        public VRTK_ControllerEvents myController;
        protected enum MyCastState { Held, Thrown, Idle };
        protected MyCastState curCast = MyCastState.Idle;
        protected enum MySpellState { Bolt, Shield, Default };
        protected MySpellState curSpell;
        public GameObject targetEnemy;
        protected GameObject[] enemies;
        public GameObject caster;
        Vector3[] enemyPositions;
        bool hasEnemies = false;
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
        float myDist = 0f;
        protected virtual void SetSpellState() {
            curSpell = MySpellState.Default;
            //overriden by their spells to set the state for debugging.
        }

        protected virtual void Start() {
            SetSpellState();
        }

        protected virtual void FindEnemies() {
            //either gets a list of all tagged enemies or a list of all enemies minus the caster (for AI casting)
            if (caster == Camera.main.gameObject) {
                //the caster is the player
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                //simply find all enemy "Enemy"s
            }

            else {
                GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
                //else targets are all "Enemy"
                List<GameObject> allTargets = new List<GameObject>();
                //make a new list called allTargets
                for (int i = 0; i < targets.Length; i++) {
                    allTargets.Add(targets[i]);
                    //for the list of allTargets, add all enemies
                }
                allTargets.Add(Camera.main.gameObject);
                //add the player to the list
                allTargets.Remove(caster);
                //then remove the caster from the list
                enemies = new GameObject[allTargets.Count];
                //set the enemy length to be the same as the length of the list
                for (int t = 0; t < enemies.Length; t++) {
                    enemies[t] = allTargets[t];
                    //set the enemy array to be the same as the enemy list
                }
            }
        }


        protected virtual void Update() {
            switch (curCast) {
                case MyCastState.Idle:
                    //idlestuff
                    break;
                case MyCastState.Held:
                    if (!hasEnemies) {
                        hasEnemies = true;
                        FindEnemies();
                        enemyPositions = new Vector3[enemies.Length];
                    }
                    TargetFind();
                    break;
                case MyCastState.Thrown:
                    SpellCast();
                    break;
            }
        }

        protected virtual void TargetFind() {
            if (enemies != null) {
                targetEnemy = enemies[Random.Range(0, enemies.Length)];
            }
        }

        protected virtual void SpellCast() {
            Debug.LogError(curSpell + " has cast but is not overriding. Despite setting state, other Scripts seem to be missing or are throwing errors.");
        }

        public virtual void OnSpellUngrab() {
            hasEnemies = false;
        }

        public virtual void OnSpellGrab() {
            //find out if holder is Camera.main.gameObject somehow
            caster = Camera.main.gameObject;
            hasEnemies = false;
            curCast = MyCastState.Held;
        }
    }
}
