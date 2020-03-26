using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    static GameObject swapMessage;
    PlayerStats stats;

    private void Awake()
    {
        if (null == swapMessage)
        {
            swapMessage = GameObject.FindGameObjectsWithTag("Message")[1];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            PlayerStats stats = player.GetComponentInChildren<PlayerStats>();

            if (stats.GetControllerNumber() == 1)
            {
                // Make Thor die 
                stats.SetLives(stats.GetLives() - 1);
                stats.DontMove();
                FindObjectOfType<AudioManager>().PlaySound("FallScream");
                // Switch to Valk to fly out
                swapMessage.transform.position = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 1);
                swapMessage.SetActive(true);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponentInChildren<PlayerStats>();
            if (stats.GetControllerNumber() == 1)
            {
                stats.DontMove();
            }
        }
    }
}
