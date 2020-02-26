﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        // Grab enemy type damage
    }

    // collided with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Add player damage
            collision.gameObject.GetComponentInChildren<PlayerStats>().DamagePlayer(damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Projectile" ||
            collision.gameObject.tag == "Type2Enemy")
        {
      
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
