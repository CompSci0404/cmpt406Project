using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelAI : AIClass
{
    private bool phaseTwo; 

    public void PhaseCheck()
    {
        // we will rebuild decision trees when it comes time to switching to phase 2.
        if(phaseTwo == false)
        {

            DecisionTree enemySpotted = new DecisionTree();
            enemySpotted.BuildDecision(EnemySpotted);

            DecisionTree canSpawnChoice = new DecisionTree();
            canSpawnChoice.BuildDecision(CanSpawn);

            DecisionTree spawnUnit = new DecisionTree();

            spawnUnit.BuildAction(SpawnUnits);

            DecisionTree rngAttack = new DecisionTree();

            rngAttack.BuildAction(LaserBeamAttack);

            DecisionTree idleChoice = new DecisionTree();

            idleChoice.BuildAction(Idle);

            enemySpotted.Right(canSpawnChoice);
            enemySpotted.Left(idleChoice);

            canSpawnChoice.Right(spawnUnit);
            canSpawnChoice.Left(rngAttack);
            this.rootOfTree = enemySpotted; 

        }
        // later for when we want to do phase2. 
    }

    // Start is called before the first frame update
    void Start()
    {
        phaseTwo = false;

        SetSaveSpeed();
        FindPlayer();
        SetCooldown();
        BuildRangePrefabs();
        FindProj("helLaser");
        FindAIPrefab("Draugr");

        PhaseCheck();

    }

    // Update is called once per frame
    void Update()
    {

        this.rootOfTree.Search(); 
        
    }
}
