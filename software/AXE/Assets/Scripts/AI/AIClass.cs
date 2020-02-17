using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIClass : MonoBehaviour
{
    public float speed;
    public float fov;
    public float health;
    public float atkDamage;

    protected DecisionTree rootOfTree;
    private float saveSpeed;
    private GameObject ply; 

    //---[[pre-setup calls THESE NEED TO BE CALLED BEFORE ANYTHING!]]---//

    public void setSaveSpeed()
    {
        this.saveSpeed = speed; 
    }


    public void FindPly()
    {
        this.ply = GameObject.FindWithTag("Player"); 

    }

    // --- [[ Damage to AI: ]] ---//

    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0) { Die(); }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    //---[[Movement Decisions]]---//

    public bool EnemySpotted()
    {
        if (Vector2.Distance(this.transform.position, ply.transform.position) < this.fov)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //---[[Movement Actions!]]---//

    public void MoveTowardsPly()
    {
        speed = saveSpeed;
        this.transform.position = Vector2.MoveTowards(this.transform.position, ply.transform.position, speed * Time.deltaTime);
    }

    public void MoveAwayFromPly()
    {
        speed = saveSpeed;
        this.transform.position = -(Vector2.MoveTowards(this.transform.position, ply.transform.position, speed * Time.deltaTime));

    }

    public void Idle()
    {
        this.speed = 0f;
    }



}
