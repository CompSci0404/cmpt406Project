using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class will create a pick up message when the player gets close to an object that can be picked up
/// </summary>
public class PickMeUp : MonoBehaviour
{
    GameObject[] GameObjects;
    GameObject PickupMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObjects = FindObjectsOfType<GameObject>();
            for(int i=0; i < GameObjects.Length;i++)
            {
                if(GameObjects[i].CompareTag("Message"))
                {
                    PickupMessage = GameObjects[i];
                }
            }
            PickupMessage.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickupMessage.transform.position = new Vector3(0, 0, 200);
        }
        else
        {
            return;
        }
    }
}
