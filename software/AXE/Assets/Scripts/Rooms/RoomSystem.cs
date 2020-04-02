using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    bool isClear = false;

    [SerializeField]
    Transform doorParent;

    public AudioClip newTrack;

    private MusicManager MManager;

    // Start is called before the first frame update
    void Start()
    {
        MManager = FindObjectOfType<MusicManager>();
    }

    public void ChangeTrack()
    {
        MManager.ChangeMusic(newTrack);
    }

    void PlayerEnter()
    {
        if (!isClear)
        {
            for (int i = 0; i < doorParent.childCount; i++)
            {
                Transform door = doorParent.GetChild(i);
                door.SendMessage("TurnOff");
            }
        }
        ChangeTrack();
    }

    void RoomClear()
    {
        isClear = true;
        for (int i = 0; i < doorParent.childCount; i++)
        {
            Transform door = doorParent.GetChild(i);
            door.SendMessage("TurnOn");
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
