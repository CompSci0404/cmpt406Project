using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowSpawn : AIClass
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<EnemyAnim>().Attack();
            collision.gameObject.GetComponentInChildren<PlayerStats>().DamagePlayer(this.atkDamage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSaveSpeed();
        FindPlayer();
        SetCooldown();
        FindEnemyParticle("Prefabs/EnemyParticle");

        DecisionTree MeleeTree = new DecisionTree();

        MeleeTree.BuildDecision(this.EnemySpotted);

        DecisionTree aiMove = new DecisionTree();

        aiMove.BuildAction(this.MoveTowardsPlayer);

        DecisionTree aiIdle = new DecisionTree();

        aiIdle.BuildAction(this.Idle);

        MeleeTree.Right(aiMove);
        MeleeTree.Left(aiIdle);

        rootOfTree = MeleeTree;



    }

    // Update is called once per frame
    void Update()
    {
        this.rootOfTree.Search(); 
    }
}
