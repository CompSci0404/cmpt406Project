using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInWorld : MonoBehaviour
{
    public Vector2 gridWorldSize; 
    public ANode[,] grideOfNodes;   /*this is creating our own grid of the room this AI is in.*/
    public float nodeRadius;
    public int cellSize; 
    public int gridX;
    public int gridY;

    private LayerMask Wall;
    private LayerMask Pit; 

    // Start is called before the first frame update
    void Start()
    {
        Wall = LayerMask.GetMask("wall");
        Pit = LayerMask.GetMask("pit");

        grideOfNodes = new ANode [gridX, gridY];

        for(int x = 0; x < gridX; x++)
        {
            for(int y = 0; y < gridY; y++)
            {
                Vector2 position = new Vector2(x, y);

               // bool objectCollided = Physics2D.OverlapCircle(GridToWorld(position + GetLeftCorner(), false ));

            }

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
