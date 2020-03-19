using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public bool isCyberWizard;
    public bool isDragur;
    public bool isNanoGhost;
    private bool dead;

    private Animator ani; 
    private string oldAct;
    private string currentAct;
    private float oldPos = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();

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
        ani.SetTrigger("Death");
    }

    // For Draugr attack trigger only!
    public void Attack()
    {
        if (!dead) ani.SetTrigger("Attack");
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
    } 
}
