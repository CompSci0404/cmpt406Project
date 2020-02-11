﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : AIClass
{
    public float atkSpeed, shotSpeed, range;

    private float playerInRangeX, playerInRangeY, shootProjectile;

    public GameObject projectile;
    private Transform player;
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

    private void fireProjectile()
    {
        GameObject shotFired = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        target = player.transform.position - transform.position;
        //float distance = target.magnitude;
        //Vector2 direction = target / distance;
        shotFired.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.x * shotSpeed, target.y * shotSpeed));
    }
}
