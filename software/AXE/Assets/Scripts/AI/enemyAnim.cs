using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnim : MonoBehaviour
{

    public bool isCyberWizard;
    public bool isDragur;
    public bool isNanoGhost;
    private bool dead;

    private Animator ani; 
    private string oldAct;
    private string currentAct;
    private float oldPos = 0.0f;
    


    public void updateCurrentAct(string updatedAct)
    {
        this.currentAct = updatedAct;
        //print(currentAct + "we in this");
    }
    public void death()
    {
        dead = true;
        ani.SetTrigger("Death");
    }

    public void playAnim() {
        
                
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
                if (currentAct.Equals("attack"))
                {
                    ani.SetTrigger("Attack");
                }  
                else if (currentAct.Equals("idle"))
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
            //if (currentAct != oldAct)
            //{
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

        if(!dead) playAnim();
        //print(currentAct);
    }
}
