using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : AIClass
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

    public void MoveAway()
    {
        speed = saveSpeed;
        this.transform.position = -(Vector2.MoveTowards(this.transform.position, ply.transform.position, speed * Time.deltaTime));
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

        DecisionTree inRangeNode = new DecisionTree();

        inRangeNode.buildDecision(EnemySpotted);

        DecisionTree AiMove = new DecisionTree();
        AiMove.buildAction(Move);

        //DecisionTree AiMoveAway = new DecisionTree();
        //AiMove.buildAction(MoveAway);

        DecisionTree AIidle = new DecisionTree();
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
