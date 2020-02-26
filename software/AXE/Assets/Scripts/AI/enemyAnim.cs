using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnim : MonoBehaviour
{

    private Animator ani; 
    private string oldAct;
    private string currentAct;
    


    public void updateCurrentAct(string updatedAct)
    {
        this.currentAct = updatedAct; 
    }

    public void playAnim() {
        
        
        if(currentAct != oldAct)
        {

            oldAct = currentAct;
            {
                if (currentAct.Equals("attack"))
                {
                    ani.SetBool("Attacking", true);
                }else if (currentAct.Equals("idle"))
                {
                    ani.SetBool("Attacking", false); 
                } else if (currentAct.Equals("move"))
                {
                    ani.SetBool("Attacking", false);
                    ani.SetTrigger("Teleport");
                }
            }

        }
    
    } 

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        playAnim(); 
    }
}
