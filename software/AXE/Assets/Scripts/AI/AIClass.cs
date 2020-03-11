﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIClass : MonoBehaviour
{
    public float speed;
    public float fov;
    public float range;
    public float health;
    public int atkDamage = 1;
    public float tooCloseRange;    /*only enforced when this unit is retreating*/
    public float velocityOfRangedAttack;
    public float rangedAttackCooldown; 

    protected DecisionTree rootOfTree;

    private float saveSpeed;
    private GameObject player;
    private List<GameObject> rangePrefabs; /*like a library of all projectiles */
    private float cooldown;
    private string currentAct;
    private float teleportCoolDown = 0;
    private float teleportTimerSet = 6;

    //---[[pre-setup calls]]---//

    public void SetSaveSpeed()
    {
        this.saveSpeed = speed; 
    }

    public void FindPlayer()
    {
        this.player = GameObject.FindWithTag("Player"); 
    }

    public void SetCooldown()
    {
        this.cooldown = 0; 
    } 

    public void BuildRangePrefabs()
    {
        rangePrefabs = new List<GameObject>(); 

        object[] prefabs;
        int counter = 0; 

        prefabs = Resources.LoadAll("rangeAttacks", typeof(GameObject)); 

        while(counter < prefabs.Length)
        {
            GameObject newItem = (GameObject)prefabs[counter];

            rangePrefabs.Add(newItem);

            counter++; 
        }
    } 

    // --- [[ Damage to AI: ]] ---//

    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log( "AI Health: " + health);
        if (health <= 0) { Die(); }
    }

    public void Die()
    {
        SendMessageUpwards("EnemyDestroyed", gameObject, SendMessageOptions.RequireReceiver);
        Destroy(this.gameObject);
    }

    //---[[range attack actions]]---//

    public void RangedAttack()
    {

        if (cooldown != 0)
        {
            this.cooldown -= Time.deltaTime;

            if (this.cooldown <= 0)
            {
                this.cooldown = 0;
            }
        }
        else if (cooldown == 0)
        {

            this.currentAct = "attack";

            this.gameObject.GetComponent<enemyAnim>().updateCurrentAct(currentAct);

            // direction that AI is currently facing is where we want to shoot our object!
            Vector2 direction = (player.transform.position - this.transform.position).normalized;

            GameObject newProjectile = Instantiate(rangePrefabs[0], this.transform.position, Quaternion.identity);

            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            newProjectile.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

            Physics2D.IgnoreCollision(newProjectile.GetComponent<PolygonCollider2D>(), this.gameObject.GetComponent<PolygonCollider2D>(), true);

            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * velocityOfRangedAttack);

            cooldown = this.rangedAttackCooldown;

            Destroy(newProjectile, 3.0f); 
        }
    }

    //---[[Movement Decisions]]---//

    public bool EnemySpotted()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < this.fov)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TooClose()
    {
        if(Vector2.Distance(this.transform.position, player.transform.position) < tooCloseRange)
        {
            return true;
        }
        else
        {

            return false; 
        }
    }

    public bool CheckRange()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < this.range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //---[[Movement Actions!]]---//

    public void MoveTowardsPlayer()
    {
        speed = saveSpeed;
        this.currentAct = "move";
        this.gameObject.GetComponent<enemyAnim>().updateCurrentAct(currentAct);
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    /*This is more like a teleport we should keep it.*/
    public void Teleport()
    {

        // teleport cooldown.
        if (teleportCoolDown != 0)
        {
            this.teleportCoolDown -= Time.deltaTime;

            if (this.teleportCoolDown <= 0)
            {
                this.teleportCoolDown = 0;
            }
        }
        else if (teleportCoolDown == 0)
        {
            speed = saveSpeed;
            this.currentAct = "move";
            this.gameObject.GetComponent<enemyAnim>().updateCurrentAct(currentAct);
            teleportCoolDown = teleportTimerSet;

            StartCoroutine(PlayAnim());

        }

    }


    private IEnumerator PlayAnim()
    {
            
        yield return new WaitForSeconds(2.0f);
        Debug.Log("after teleport coroutine");
        this.transform.position = -(Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime));

    }

    public void MoveAwayFromPlayer()
    {
        speed = saveSpeed;
        this.currentAct = "move";
        this.gameObject.GetComponent<enemyAnim>().updateCurrentAct(currentAct);
        Vector2 direction = this.gameObject.transform.position - player.transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime); 

    }

    public void Idle()
    {
        this.currentAct = "idle";
        this.gameObject.GetComponent<enemyAnim>().updateCurrentAct(currentAct);
        this.speed = 0f;
    }

    public string ReturnCurrentAct()
    {
        return this.currentAct;
    }


}
