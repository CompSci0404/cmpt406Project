using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// <c>ANode</c>
/// 
/// Helper class Anode,
/// will contain all data required to make a educated guess
/// on which point in the 2d grid we need to move towards to get
/// to the target(Player). 
/// 
/// </summary>

public class ANode
{
    public Vector2 point;           /*position that the algorithim is at.*/
    public bool objectDetected;     /* have we hit object we do not want to hit?*/
    public float g, h;                /*g cost, Distance from the starting node. h cost, distance from end node.*/

    public float f                    /*fcost, sum of h and g cost movement done.*/
    {
        get
        {
            return g + h;
        }
    }

    ANode(int gridX, int gridY, bool objDec, float gVal, float hVal)
    {
        this.point = new Vector2(gridX, gridY); 
        objectDetected = objDec;
        g = gVal;
        h = hVal; 

    }

    public string ToString()
    {

        return "point: " + point + "f cost for this point: " + f; 
    }
}
