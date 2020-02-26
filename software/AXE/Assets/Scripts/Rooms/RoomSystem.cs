using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    bool isClear = false;

    List<Transform> doors;

    // Start is called before the first frame update
    void Start()
    {
        doors = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RoomClear()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.CompareTag("Player"))
        {
            return;
        }

        SendMessage("PlayerEnter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.CompareTag("Player"))
        {
            return;
        }

        SendMessage("PlayerExit");
    }
}
