using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A shield of barely contained transparent energy enveloping the user; blocks one blow then detonates pushing back any nearby enemies.
/// </summary>
public class EnergyShield : ItemClass
{
    float radius = 0.8f;

    private GameObject energyShield;

    private GameObject playerCont;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = SpawnShield;
        energyShield = this.gameObject;
        playerCont = GameObject.FindWithTag("Player");
    }

    void SpawnShield()
    {
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Instantiate(energyShield, playerCont.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("BaseEnemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
