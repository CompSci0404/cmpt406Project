using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    // collided with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Player")
        {
            // Add player damage
            other.GetComponentInChildren<PlayerStats>().DamagePlayer(damage);
            Destroy(gameObject);
        }
        else if(other.tag == "Projectile" ||
            other.tag == "BaseEnemy" || 
            other.tag == "Arrow")
        {
            // do nothing
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
