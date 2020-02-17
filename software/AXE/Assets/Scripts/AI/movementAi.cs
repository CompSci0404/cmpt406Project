using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAi : AIClass
{
    private float saveSpeed;
    private GameObject ply; 

    public bool EnemySpotted()
    {
        if (Vector2.Distance(this.transform.position, ply.transform.position) < this.fov)
        {

            return true;
        } else
        {
            return false;
        
        }
    }

    public void Move()
    {
        speed = saveSpeed;
        this.transform.position = Vector2.MoveTowards(this.transform.position, ply.transform.position, speed * Time.deltaTime); 
    }


    public void Idle()
    {
        this.speed = 0f; 
    }

    // Start is called before the first frame update
    void Start()
    {
        saveSpeed = speed;
        ply = GameObject.FindWithTag("Player");

        decisionTree inRangeNode = new decisionTree();

        inRangeNode.buildDecision(EnemySpotted);

        decisionTree AiMove = new decisionTree();
        AiMove.buildAction(Move);

        decisionTree AIidle = new decisionTree();
        AIidle.buildAction(Idle);

        inRangeNode.Right(AiMove);
        inRangeNode.Left(AIidle);

        rootOfTree = inRangeNode; 
        
    }

    // Update is called once per frame
    void Update()
    {
        rootOfTree.search(); 

    }
}
