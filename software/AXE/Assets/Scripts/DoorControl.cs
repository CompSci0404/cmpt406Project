using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will be activated when the player runs into the door tilemap collider
/// </summary>
public class DoorControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Move to next room code. 
            Debug.Log("Player wants to leave the room");
        }
    }
}
