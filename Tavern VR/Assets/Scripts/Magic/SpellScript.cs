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

        protected virtual void HighlightTarget()
        {
            if (caster == Camera.main.gameObject)
            {
                if (targetEnemy.GetComponent<ParticleSystem>() == null)
                {
                    targetEnemy.AddComponent<ParticleSystem>();
                }
                else
                {
                    targetEnemy.GetComponent<ParticleSystem>().Play();
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
                    HighlightTarget();
                    break;
                case MyCastState.Thrown:
                    SpellCast();
                    break;
            }
        }

        protected virtual void TargetFind() {
            if (caster == Camera.main.gameObject) {
                //if caster is player, targets enemy closest to center of screen
                if (enemies != null) {
                    for (int i = 0; i < enemies.Length; i++) {
                        if (Camera.main.WorldToViewportPoint(enemies[i].transform.position) != null) {
                            enemyPositions[i] = Camera.main.WorldToViewportPoint(enemies[i].transform.position);
                        }
                        enemyPositions[i] = new Vector3(enemyPositions[i].x, enemyPositions[i].y, 0f);
                        if (targetEnemy != null) {
                            if (Vector3.Distance(enemyPositions[i], screenCenter) < myDist) {
                                if (targetEnemy != null && targetEnemy.GetComponent<ParticleSystem>() != null)
                                {
                                    targetEnemy.GetComponent<ParticleSystem>().Stop();
                                }
                                //Debug.Log(enemyPositions[i] + " this is the" + i + " position");
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
            }
            else {
                //AI targets random from list
                if (enemies != null) {
                    targetEnemy = enemies[Random.Range(0, enemies.Length)];
                }
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
