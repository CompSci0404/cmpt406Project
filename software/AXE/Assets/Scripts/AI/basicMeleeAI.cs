using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMeleeAI : AIClass
{
    // Start is called before the first frame update
    void Start()
    {
        //we build the entire AI here, always grab the pre-set up functions, then contruct the 
        //ai decision tree depending on how it functions!

        this.setSaveSpeed();
        this.FindPly();

        DecisionTree R = new DecisionTree();

        R.buildDecision(this.EnemySpotted);

        DecisionTree aiMove = new DecisionTree();

        aiMove.buildAction(this.MoveTowardsPly);

        DecisionTree aiIdle = new DecisionTree();

        aiIdle.buildAction(this.Idle);

        R.Right(aiMove);
        R.Left(aiIdle);

        rootOfTree = R; 

    }

    // Update is called once per frame
    void Update()
    {
        this.rootOfTree.search(); 
    }
}
