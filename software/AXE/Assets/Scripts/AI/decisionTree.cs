﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree
{

    // delegates:

    public delegate bool Decision(); // every function that is a decision must be a boolean.
    public delegate void Action(); // every function that is a Action MUST be a void.



    Action action; // I can create varaibles for each of my Delegates.
    Decision decision;
    DecisionTree leftNode;
    DecisionTree rightNode;

    public DecisionTree()
    {

        this.action = null;
        this.decision = null;
        this.leftNode = null;
        this.rightNode = null;

    }

    /**
	 * void buildDecision: 
	 * param: aiChoice: this is the decision that the AI will make at this node.
	 * 
	 * assigns the decision delegate to the function placed in aichoice variable.
	 * 
	 * return Nothing
	 * 
	 */

    public void BuildDecision(Decision aiChoice)
    {

        this.decision = aiChoice;


    }

    /**
	 * void buildAction: 
	 * param: aiAction: this is the action that the AI will make at this node.
	 * 
	 * assigns the action delegate to the function placed in aiAction variable.
	 * 
	 * return Nothing
	 * 
	 */


    public void BuildAction(Action aiAction)
    {

        this.action = aiAction;

    }

    /**
	 * void left: 
	 * param: LeftNode: The left node of the parent called
	 * 
	 * sets the left Node of the this parent.
	 * 
	 * return Nothing
	 * 
	 */


    public void Left(DecisionTree leftNode)
    {


        this.leftNode = leftNode;

    }


    /**
	 * void Right: 
	 * param: RightNode: The right node of the parent called
	 * 
	 * sets the right Node of the this parent.
	 * 
	 * return Nothing
	 * 
	 */
    public void Right(DecisionTree rightNode)
    {

        this.rightNode = rightNode;
    }

    /**
	 * recusvily search throughout my tree until find the correct action to take. 
	 */
    public void Search()
    {

        if (action != null)
        {

            action();


        }
        else if (this.decision())
        {

            rightNode.Search();

        }
        else
        {
            leftNode.Search();
        }


    }


}