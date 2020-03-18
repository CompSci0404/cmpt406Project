using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class will create a pick up message when the player gets close to an object that can be picked up
/// </summary>
public class PickMeUp : MonoBehaviour
{
    GameObject[] GameObjects;
    GameObject pickupMessage;

    private void Awake()
    {
        pickupMessage = GameObject.FindGameObjectsWithTag("Message")[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pickupMessage.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1);
            pickupMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickupMessage.SetActive(false);
        }
    }
}
