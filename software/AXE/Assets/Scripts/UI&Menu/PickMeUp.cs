using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Class will create a pick up message when the player gets close to an object that can be picked up
/// </summary>
public class PickMeUp : MonoBehaviour
{
    static GameObject pickupMessage;

    private ScriptableControls myControls;
    private void Awake()
    {
        if (null == pickupMessage)
        {
            pickupMessage = GameObject.FindGameObjectsWithTag("Message")[0];
            
        }
    }
    private void Update()
    {
        
        if (pickupMessage != null)
        {
            myControls = (ScriptableControls)Resources.Load("MyControls");
            if (myControls.PC)
            {
                pickupMessage.GetComponentInChildren<TextMeshProUGUI>().SetText("Press 'E' to pick me up!");
            }
            else
            {
                pickupMessage.GetComponentInChildren<TextMeshProUGUI>().SetText("Press 'X' to pick me up!");
            }
        }
        
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
