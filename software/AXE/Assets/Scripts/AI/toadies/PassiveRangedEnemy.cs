using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Higher ranged enemy that moves away from the player to attack
/// </summary>
public class PassiveRangedEnemy : AIClass
{

    // Start is called before the first frame update
    void Start()
    {

        this.SetSaveSpeed();
        this.FindPlayer();
        this.SetCooldown();
        this.BuildRangePrefabs();
        this.findProj("FireProjectile");

        //---[[building decision tree:]]---//

        DecisionTree enemySpotted = new DecisionTree();

        enemySpotted.BuildDecision(this.EnemySpotted);

        DecisionTree tooClose = new DecisionTree();
        tooClose.BuildDecision(this.TooClose);

        DecisionTree runAway = new DecisionTree();
        runAway.BuildAction(this.MoveAwayFromPlayer);

        DecisionTree attack = new DecisionTree();
        attack.BuildAction(this.RangedAttack);

        DecisionTree idleChoice = new DecisionTree();
        idleChoice.BuildAction(this.Idle);

        enemySpotted.Right(tooClose);
        enemySpotted.Left(idleChoice);
        tooClose.Right(runAway);
        tooClose.Left(attack);

        this.rootOfTree = enemySpotted; 
    }

    // Update is called once per frame
    void Update()
    {
        this.rootOfTree.Search(); 
    }
}
