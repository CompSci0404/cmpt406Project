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
    public float toCloseRng;    /*only enforced when this unit is retreating*/
    public float VelocityOfRngAtck;
    public float rngAttackCoolDown; 

    protected DecisionTree rootOfTree;

    private float saveSpeed;
    private GameObject ply;
    private List<GameObject> rngPrefabs; /*like a library of all projectiles */
    private float coolDown;

    //---[[pre-setup calls]]---//

    public void setSaveSpeed()
    {
        this.saveSpeed = speed; 
    }


    public void FindPly()
    {
        this.ply = GameObject.FindWithTag("Player"); 

    }

    public void setcoolDown()
    {

        this.coolDown = 0; 
    } 

    public void buildRngPrefabs()
    {
        rngPrefabs = new List<GameObject>(); 

        object[] prefabs;
        int counter = 0; 

        prefabs = Resources.LoadAll("rangeAttacks", typeof(GameObject)); 

        while(counter < prefabs.Length)
        {

            GameObject newItem = (GameObject)prefabs[counter];

            rngPrefabs.Add(newItem);

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
        Destroy(this.gameObject);
    }

    //---[[range attack actions]]---//

    public void rngAttackPly()
    {

        if (coolDown != 0)
        {

            this.coolDown -= Time.deltaTime;

            if (this.coolDown <= 0)
            {
                this.coolDown = 0;
            }


        }
        else if (coolDown == 0)
        {

            // direction that AI is currently facing is where we want to shoot our object!
            Vector2 direction = (ply.transform.position - this.transform.position).normalized;

            GameObject newProjectile = Instantiate(rngPrefabs[0], this.transform.position, Quaternion.identity);

            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            newProjectile.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);

            Physics2D.IgnoreCollision(newProjectile.GetComponent<PolygonCollider2D>(), this.gameObject.GetComponent<PolygonCollider2D>(), true);

            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * VelocityOfRngAtck);

            coolDown = this.rngAttackCoolDown;

            Destroy(newProjectile, 3.0f); 
        }

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

    public bool toClose()
    {
        if(Vector2.Distance(this.transform.position, ply.transform.position) < toCloseRng)
        {
            return true;
        }else
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

    /*This is more like a teleport we should keep it.*/
    public void Teleport()
    {
        speed = saveSpeed;
        this.transform.position = -(Vector2.MoveTowards(this.transform.position, ply.transform.position, speed * Time.deltaTime));

    }

    public void MoveAwayFromPly()
    {
        speed = saveSpeed;

        Vector2 direction = this.gameObject.transform.position - ply.transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime); 

    }

    public void Idle()
    {
        this.speed = 0f;
    }



}
