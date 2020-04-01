using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    bool isClear = false;

    [SerializeField]
    Transform doorParent;

    [SerializeField]
    GameObject Teleporter;

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
                Door door = doorParent.GetChild(i).GetComponent<Door>();
                door.TurnOff();
            }
            if (Teleporter.TryGetComponent(out Teleport teleportScript))
            {
                teleportScript.TurnOff();
            }
        }
        ChangeTrack();
    }

    void RoomClear()
    {
        isClear = true;
        for (int i = 0; i < doorParent.childCount; i++)
        { 
            Door door = doorParent.GetChild(i).GetComponent<Door>();
            door.TurnOn();
        }
        if (Teleporter.TryGetComponent(out Teleport teleportScript))
        {
            teleportScript.TurnOn();
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
