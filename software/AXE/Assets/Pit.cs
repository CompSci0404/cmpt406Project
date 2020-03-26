using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            PlayerStats stats = player.GetComponentInChildren<PlayerStats>();
            if(stats.GetControllerNumber() == 1)
            {
                // Make Thor take Damage 
            }
            else
            {
                // Valk can fly
            }
        }
        else if (collision.CompareTag("BaseEnemy"))
        {
            Debug.Log("enemyHas been choosen!");
            if(collision.GetComponent<EnemyAnim>().isDragur)
            {
                // floor enemies should avoid the pits at all costs    


                collision.GetComponent<pathFinding>().setPitCollision(true, this.gameObject); 

                print("Enemy is dragur");
            }
            else
            { 
                // Enemy can fly
            }
        }
        else
        {
            // do nothing
        }
    }
}
