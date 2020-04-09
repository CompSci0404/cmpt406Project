using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public bool isCyberWizard;
    public bool isDragur;
    public bool isNanoGhost;
    public bool isHel;
    public bool isShadow; 

    private bool dead;

    private Animator ani; 
    private string oldAct;
    private string currentAct;
    private float oldPos = 0.0f;

    //Variables for Hel specifically
    private Vector2 pos;
    private Vector2 playerPos;
    private GameObject player;
    private int state;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        currentAct = "";
        oldAct = "";

        this.oldPos = this.transform.position.x;
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead) PlayAnim();
        //print(currentAct);
    }

    public void UpdateCurrentAct(string updatedAct)
    {
        this.currentAct = updatedAct;
        //print(currentAct + "we in this");
    }

    public void Death()
    {
        dead = true;

        if (isShadow == false)
        {
            ani.SetTrigger("Death");
        }
    }

    // For Draugr attack trigger only!
    public void Attack()
    {

            if (!dead) ani.SetTrigger("Attack");
        
    }

    // For Hel laser attack only!
    public void HelLaser()
    {
        if (!dead) ani.SetTrigger("Laser");
    }

    public void PlayAnim()
    {         
        if (isCyberWizard)
        {
            if (currentAct != oldAct)
            {
                if (currentAct.Equals("attack"))
                {
                    ani.SetBool("Attacking", true);
                }
                else if (currentAct.Equals("idle"))
                {
                    ani.SetBool("Attacking", false);
                }
                else if (currentAct.Equals("move"))
                {
                    ani.SetBool("Attacking", false);
                    ani.SetTrigger("Teleport");
                }
            oldAct = currentAct;
            }
        } 
        else if (isDragur)
        {
            if (currentAct.Equals("idle"))
            {
                ani.SetFloat("Speed", 0.0f);
            } else if (currentAct.Equals("move"))
            {
                // left: 
                if (oldPos < this.transform.position.x)
                {
                    ani.SetFloat("Speed", 0.02f );
                }

                // right
                if (oldPos > this.transform.position.x)
                {
                    ani.SetFloat("Speed", -0.02f);
                }
                oldPos = this.transform.position.x; 
            }      
        }
        else if (isNanoGhost)
        {
            if (currentAct.Equals("attack"))
            {
                ani.SetBool("Attacking", true);
            }
            if (currentAct.Equals("idle"))
            {
                ani.SetBool("Attacking", false);
                ani.SetFloat("Speed", 0.0f);
            }
            if (currentAct.Equals("move"))
            {
                ani.SetBool("Attacking", false);
                // left: 
                if (oldPos < this.transform.position.x)
                {
                    ani.SetFloat("Speed", 0.02f);
                }

                if (oldPos > this.transform.position.x)
                {
                    ani.SetFloat("Speed", -0.02f);
                }
                oldPos = this.transform.position.x;
            }
        }
        else if (isHel)
        {
            float angle = 270.0f;
            pos = gameObject.transform.position;
            if (player != null)
            {
                playerPos = player.transform.position;
                playerPos -= pos;
                angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
                if (angle < -45.0f) angle += 360.0f;
                if ((angle > 225.0f && angle < 315.0f) || (angle > 45.0f && angle < 135.0f)) state = 0;
                else if (angle > 135.0f && angle < 225.0f) state = 1;
                else if (angle > -45.0f && angle < 45.0f) state = 2;
            }

            switch (state)
            {
                case 0:
                    //Play animation: hel_front
                    ani.SetBool("Front", true);
                    ani.SetBool("Left", false);
                    ani.SetBool("Right", false);
                    break;
                case 1:
                    //Play animation: hel_left
                    ani.SetBool("Left", true);
                    ani.SetBool("Front", false);
                    ani.SetBool("Right", false);
                    break;
                case 2:
                    //Play animation: hel_right
                    ani.SetBool("Right", true);
                    ani.SetBool("Front", false);
                    ani.SetBool("Left", false);
                    break;
                default:
                    throw new System.ArgumentException("Invalid animation state", "state");
            }
        }
        else if (isShadow)
        {
            if (currentAct.Equals("idle"))
            {
                ani.SetFloat("speed", 0.0f);

            } 
            else if (currentAct.Equals("move"))
            {

                if (oldPos < this.transform.position.x)
                {
                    ani.SetFloat("speed", -0.02f);
                }

                if (oldPos > this.transform.position.x)
                {
                    ani.SetFloat("speed", 0.02f);
                }

                oldPos = this.transform.position.x;

            }

        }
    } 
}
