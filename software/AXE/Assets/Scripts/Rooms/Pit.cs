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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        Collider2D pitCollider = gameObject.GetComponent<Collider2D>();

        if (obj.CompareTag("Player"))
        {
            PlayerMovement player = obj.GetComponent<PlayerMovement>();
            PlayerStats stats = player.GetComponentInChildren<PlayerStats>();

            Collider2D playerCollider = obj.GetComponent<Collider2D>();

            if (stats.GetControllerNumber() == 1)
            {
                //// Make Thor die 
                //stats.DontMove();
                //FindObjectOfType<AudioManager>().PlaySound("FallScream");
                //// Switch to Valk to fly out
                //swapMessage.transform.position = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 1);
                //swapMessage.SetActive(true);
            }
            else
            {
                //Physics2D.IgnoreCollision(pitCollider, playerCollider);
                // Valk can fly
            }
        }
        else if (obj.CompareTag("BaseEnemy"))
        {
            Collider2D enemyCollider = obj.GetComponent<Collider2D>();
            if(obj.GetComponent<EnemyAnim>().isDragur)
            {
                // floor enemies should avoid the pits at all costs
                //collision.gameObject.GetComponent<PathFinding>().SetPitCollision(true, this.gameObject); 
            }
            else
            {
                // Enemy can fly
                Physics2D.IgnoreCollision(pitCollider, enemyCollider);
            }
        }
        else if (obj.CompareTag("Projectile") || obj.CompareTag("Arrow"))
        {
            Physics2D.IgnoreCollision(pitCollider, obj.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            swapMessage.SetActive(false);
            //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), false);
        }

        else if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Arrow"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.GetComponent<Collider2D>());
        }
    }
}
