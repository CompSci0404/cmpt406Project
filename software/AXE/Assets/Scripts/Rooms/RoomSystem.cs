using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    bool isClear = false;

    [SerializeField]
    Transform doorParent;

    void PlayerEnter()
    {
        if (!isClear)
        {
            for (int i = 0; i < doorParent.childCount; i++)
            {
                Transform door = doorParent.GetChild(i);

                door.gameObject.SetActive(false);
            }
        }
    }

    void RoomClear()
    {
        isClear = true;
        for (int i = 0; i < doorParent.childCount; i++)
        {
            Transform door = doorParent.GetChild(i);

            door.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Player"))
        {
            SendMessage("PlayerEnter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Player"))
        {
            SendMessage("PlayerExit");
        }
    }
}
