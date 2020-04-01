using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorRefreshPopUp : MonoBehaviour
{
    static GameObject newPop;
    private bool doable;

    private void Awake()
    {
        if (null == newPop)
        {
            if (GameObject.FindGameObjectsWithTag("Message").Length == 3)
            {
                doable = true;
                newPop = GameObject.FindGameObjectsWithTag("Message")[2];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && doable)
        {
            newPop.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1);
            newPop.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && doable)
        {
            newPop.SetActive(false);
        }
    }
}
