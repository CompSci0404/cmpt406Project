using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class exists as a base for enemies in our game
 */
public class Enemy : MonoBehaviour
{
    void Start()
    {
        // Enemy will have stats
    }

    void Update()
    {
        // Enemy AI/Movement here?
    }

    // When player hits the enemy, do something 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Take damage stats.Damage(collision.getDamage());
            //Debug.Log("Player hit!");
        }
    }
}
