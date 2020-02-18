using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeAI : AIClass
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("I am a AI, and this is BIG DAMAGE"); 
            collision.gameObject.GetComponent<Movement>().DmgPlyer(this.atkDamage); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //we build the entire AI here, always grab the pre-set up functions, then contruct the 
        //ai decision tree depending on how it functions!

        this.SetSaveSpeed();
        this.FindPlayer();

        DecisionTree MeleeTree = new DecisionTree();

        MeleeTree.buildDecision(this.EnemySpotted);

        DecisionTree aiMove = new DecisionTree();

        aiMove.buildAction(this.MoveTowardsPlayer);

        DecisionTree aiIdle = new DecisionTree();

        aiIdle.buildAction(this.Idle);

        MeleeTree.Right(aiMove);
        MeleeTree.Left(aiIdle);

        rootOfTree = MeleeTree; 
    }

    // Update is called once per frame
    void Update()
    {
        this.rootOfTree.search(); 
    }
}
