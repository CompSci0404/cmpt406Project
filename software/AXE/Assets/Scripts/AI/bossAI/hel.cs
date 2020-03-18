using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hel : AIClass
{

    private bool phaseTwo; 

    public void phaseCheck()
    {
        // we will rebuild decision trees when it comes time to switching to phase 2.
        if(phaseTwo == false)
        {

            DecisionTree enemySpotted = new DecisionTree();
            enemySpotted.BuildDecision(this.EnemySpotted);

            DecisionTree canSpawnChoice = new DecisionTree();
            canSpawnChoice.BuildDecision(this.canSpawn);

            DecisionTree spawnUnit = new DecisionTree();

            spawnUnit.BuildAction(this.spawnUnits);

            DecisionTree rngAttack = new DecisionTree();

            rngAttack.BuildAction(this.laserBeamAttack);

            DecisionTree idleChoice = new DecisionTree();

            idleChoice.BuildAction(this.Idle);

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
        this.phaseTwo = false;

        this.SetSaveSpeed();
        this.FindPlayer();
        this.SetCooldown();
        this.BuildRangePrefabs();
        this.findProj("helLaser");
        this.findAIPrefab("Draugr");

        phaseCheck(); 

    }

    // Update is called once per frame
    void Update()
    {

        this.rootOfTree.Search(); 
        
    }
}
