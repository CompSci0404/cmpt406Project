using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Higher ranged enemy that moves away from the player to attack
 */
public class PassiveRangedEnemy : AIClass
{

    // Start is called before the first frame update
    void Start()
    {

        this.setSaveSpeed();
        this.FindPly();
        this.setcoolDown();
        this.buildRngPrefabs();


        //---[[building decision tree:]]---//

        DecisionTree enemySpotted = new DecisionTree();

        enemySpotted.buildDecision(this.EnemySpotted);

        DecisionTree tooClose = new DecisionTree();
        tooClose.buildDecision(this.toClose);

        DecisionTree runAway = new DecisionTree();
        runAway.buildAction(this.MoveAwayFromPly);

        DecisionTree attack = new DecisionTree();
        attack.buildAction(this.rngAttackPly);

        DecisionTree idleChoice = new DecisionTree();
        idleChoice.buildAction(this.Idle);

        enemySpotted.Right(tooClose);
        enemySpotted.Left(idleChoice);
        tooClose.Right(runAway);
        tooClose.Left(attack);

        this.rootOfTree = enemySpotted; 
    }

    // Update is called once per frame
    void Update()
    {
        this.rootOfTree.search(); 
    }
}
