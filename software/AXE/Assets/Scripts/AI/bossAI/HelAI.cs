using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelAI : AIClass
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //this.gameObject.GetComponent<EnemyAnim>().Attack();
            collision.gameObject.GetComponentInChildren<PlayerStats>().DamagePlayer(this.atkDamage);
        }
    }


    public void PhaseCheck()
    {
        // we will rebuild decision trees when it comes time to switching to phase 2.
        if(returnPhase() == false)
        {

            Debug.Log("We have built the first tree");
            SetSaveSpeed();
            findHalfedHealth();
            FindPlayer();
            SetCooldown();
            BuildRangePrefabs();
            FindProj("helLaser");
            FindAIPrefab("Draugr");

            DecisionTree enemySpotted = new DecisionTree();
            enemySpotted.BuildDecision(EnemySpotted);

            DecisionTree hpGanging = new DecisionTree();
            hpGanging.BuildDecision(checkHPHalfed);

            DecisionTree canSpawnChoice = new DecisionTree();
            canSpawnChoice.BuildDecision(CanSpawn);

            DecisionTree spawnUnit = new DecisionTree();
            spawnUnit.BuildAction(SpawnUnits);

            DecisionTree rngAttack = new DecisionTree();
            rngAttack.BuildAction(LaserBeamAttack);

            DecisionTree idleChoice = new DecisionTree();
            idleChoice.BuildAction(Idle);

            DecisionTree phaseActivate = new DecisionTree();
            phaseActivate.BuildAction(activatePhase2);

            enemySpotted.Right(hpGanging);
            enemySpotted.Left(idleChoice);

            hpGanging.Right(canSpawnChoice);
            hpGanging.Left(phaseActivate);

            canSpawnChoice.Right(spawnUnit);
            canSpawnChoice.Left(rngAttack);
            this.rootOfTree = enemySpotted; 

        } 
        else
        {

            Debug.Log("We have built the second tree");

            SetSaveSpeed();
            findHalfedHealth();
            FindPlayer();
            SetCooldown();
            BuildRangePrefabs();
            FindProj("helLaser");
            FindAIPrefab("shadowSpawn");

            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            DecisionTree enemySpotted = new DecisionTree();
            enemySpotted.BuildDecision(EnemySpotted);

            DecisionTree canSpawnChoice = new DecisionTree();
            canSpawnChoice.BuildDecision(CanSpawn);

            DecisionTree spawnUnit = new DecisionTree();

            spawnUnit.BuildAction(createIllusions);

            DecisionTree argAttack = new DecisionTree();

            argAttack.BuildAction(shieldedAtkMove);

            DecisionTree idleChoice = new DecisionTree();

            idleChoice.BuildAction(Idle);

            enemySpotted.Right(canSpawnChoice);
            enemySpotted.Left(idleChoice);

            canSpawnChoice.Right(spawnUnit);
            canSpawnChoice.Left(argAttack);

            this.rootOfTree = enemySpotted;

        }
        // later for when we want to do phase2. 
    }

    // Start is called before the first frame update
    void Start()
    {

        PhaseCheck();

        

    }

    // Update is called once per frame
    void Update()
    {

        this.rootOfTree.Search(); 
        
    }
}
