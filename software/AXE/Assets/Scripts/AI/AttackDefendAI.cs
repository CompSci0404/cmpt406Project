using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefendAI : AIClass
{
    protected DecisionTree rootOfTree;

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        DecisionTree inRangeNode = new DecisionTree();

        DecisionTree AiAttack = new DecisionTree();
        AiAttack.buildAction(Attack);

        DecisionTree AiDefend = new DecisionTree();
        AiDefend.buildAction(Defend);

        inRangeNode.Right(AiAttack);
        inRangeNode.Left(AiDefend);

        rootOfTree = inRangeNode;
    }

    // Update is called once per frame
    void Update()
    {
        rootOfTree.search();
    }

    public void Attack()
    {

    }

    private void Defend()
    {

    }
}
