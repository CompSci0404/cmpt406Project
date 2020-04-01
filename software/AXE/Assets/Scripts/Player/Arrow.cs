using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Arrow class that will destroy a arrow object when it hits with an enemy
/// </summary>
public class Arrow : MonoBehaviour
{
    private bool used = false;

    private float arrowDamage;


    public void SetDamage(float damage)
    {
        arrowDamage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (used) return;

        GameObject obj = collision.gameObject;

        // Check if bullent should not be destroyed
        string[] tags = { "Player", "Arrow", "Projectile"};
        for (int i = 0; i < tags.Length; i++)
        {
            if (obj.CompareTag(tags[i])) return;
        }

        // Check if collision is an enemy
        used = true;
        Destroy(gameObject);
        if (obj.CompareTag("BaseEnemy"))
        {
            obj.GetComponent<AIClass>().Damage(arrowDamage);
            return;
        }
        if (obj.CompareTag("Destructibles"))
        {
            obj.GetComponent<Destructibles>().Damage(arrowDamage);
            return;
        }
    }
}
