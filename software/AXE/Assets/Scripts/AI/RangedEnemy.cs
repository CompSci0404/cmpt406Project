using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Lower ranged enemy that moves towards the player to attack
 */
public class RangedEnemy : AIClass
{

    // Start is called before the first frame update
    void Start()
    {
        this.SetSaveSpeed();
        this.FindPlayer();
        this.SetCooldown();
        this.BuildRangePrefabs();

        DecisionTree enemySpotted = new DecisionTree();

        enemySpotted.BuildDecision(this.EnemySpotted);

        DecisionTree checkRange = new DecisionTree();
        checkRange.BuildDecision(this.CheckRange);

        DecisionTree teleportToPlayer = new DecisionTree();
        teleportToPlayer.BuildAction(this.Teleport);

        DecisionTree rangeAttack = new DecisionTree();
        rangeAttack.BuildAction(this.RangedAttack);

        DecisionTree idleChoice = new DecisionTree();
        idleChoice.BuildAction(this.Idle);

        enemySpotted.Left(idleChoice);
        enemySpotted.Right(checkRange);
        checkRange.Left(teleportToPlayer);
        checkRange.Right(rangeAttack);

        this.rootOfTree = enemySpotted;
    }

    // Update is called once per frame
    void Update()
    {
        this.rootOfTree.Search();
    }

}
