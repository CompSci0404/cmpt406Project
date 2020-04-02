using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private bool teleportUsed = false;
    Vector2 teleportFrom;
    CoinStats coins;
    GameObject Teleporter;

    private void Start()
    {
        teleportFrom = this.gameObject.transform.position;
        coins = FindObjectOfType<CoinStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 playerPosition = collision.transform.position;

            // Player is at shop
            if (playerPosition.x < 5 && playerPosition.x > -5 && playerPosition.y < 5 && playerPosition.y > -5 && teleportUsed)
            {
                // teleport back
                collision.transform.position = teleportFrom;
                teleportUsed = false;
                Destroy(this.gameObject);
            }
            else
            {
                // go to shop room
                collision.transform.position = new Vector2(-3.6f, 1.5f);
                this.gameObject.transform.position = new Vector2(0.8f, 0.4f);
                teleportUsed = true;
            }
        }
    }

    public void CreatePortal()
    {
        Vector3 teleporterLocation = new Vector3(this.GetComponentInParent<Transform>().position.x, this.GetComponentInParent<Transform>().position.y + 2, 0);
        GameObject portal = Instantiate(Teleporter, this.transform); // teleporterLocation
    }

    public void DestroyTeleporter()
    {
        // May have to destroy, maybe not. 
    }

    public void TurnOff()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void TurnOn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

}
