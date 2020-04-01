using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>pathFinding</c>
/// 
/// 
/// a real basic attempt at stopping AI from walking into pits.
/// 
/// 
/// </summary>
public class PathFinding : MonoBehaviour
{
    private float timer = 0;
    private float coolDown = 2f; 
    private GameObject itemHit;
    private bool pitHit;
    private RaycastHit2D hit; 


    public void SetPitCollision(bool hitPit, GameObject collidedItem)
    {
        pitHit = hitPit;
        itemHit = collidedItem;
        this.gameObject.GetComponent<AIClass>().giveControlToPF();
        timer = coolDown;
    }

    public void WalkAroundObject(float speed, GameObject player, GameObject ai)
    {
        //Debug.Log("pathing away from pit.");
        hit = Physics2D.Raycast(this.transform.position, player.transform.position);
        //Debug.Log(hit.transform.gameObject.tag);
        
        if(timer == 0)
        {
            this.gameObject.GetComponent<AIClass>().takeControlFromPF();
            timer = coolDown; 
        }
        else if (timer != 0)
        {
            timer -= Time.deltaTime; 

            if(timer <= 0)
            {

                timer = 0;
            }
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, Vector2.down, speed * Time.deltaTime);  
    } 
}
