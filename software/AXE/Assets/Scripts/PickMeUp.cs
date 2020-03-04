using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class will create a pick up message when the player gets close to an object that can be picked up
/// </summary>
public class PickMeUp : MonoBehaviour
{
    [SerializeField]
    GameObject PickupMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupMessage.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1);
        PickupMessage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PickupMessage.SetActive(false);
    }
}
