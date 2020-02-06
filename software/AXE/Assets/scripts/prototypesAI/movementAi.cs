using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAi : AIClass
{
    private float saveSpeed;
    private GameObject ply; 

    public bool enemySpotted()
    {
        if (Vector2.Distance(this.transform.position, ply.transform.position) < this.FOV)
        {

            return true;
        } else
        {
            return false;
        
        }
    }

    public void move()
    {
        speed = saveSpeed;
        this.transform.position = Vector2.MoveTowards(this.transform.position, ply.transform.position, speed * Time.deltaTime); 
    }


    public void idle()
    {

        this.speed = 0f; 

    }

    // Start is called before the first frame update
    void Start()
    {
        saveSpeed = speed;
        ply = GameObject.FindWithTag("Player");

        decisionTree inRangeNode = new decisionTree();

        inRangeNode.buildDecision(enemySpotted);

        decisionTree AiMove = new decisionTree();
        AiMove.buildAction(move);

        decisionTree AIidle = new decisionTree();
        AIidle.buildAction(idle);

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
