using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Lower ranged enemy that moves towards the player to attack
 */
public class RangedEnemy : AIClass
{
    public float atkSpeed, shotSpeed, range;

    private float playerInRangeX, playerInRangeY, shootProjectile;

    public GameObject projectile;
    public Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInRangeX = range;
        playerInRangeY = range;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if (Vector2.Distance(transform.position, player.position) < playerInRangeX && shootProjectile <= 0 ||
            Vector2.Distance(transform.position, player.position) < playerInRangeY && shootProjectile <= 0)
            {
            fireProjectile();
            shootProjectile = atkSpeed;
            }
        else { shootProjectile -= Time.deltaTime; }
    }

    // Shoot projectile at player
    private void fireProjectile()
    {
        GameObject shotFired = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        target = player.transform.position - transform.position;
        float distance = target.magnitude;
        Vector2 direction = target / distance;
        // Force based on target will make bullets come out slower as you approach, kind of neat
        shotFired.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * shotSpeed, direction.y * shotSpeed));
    }
}
