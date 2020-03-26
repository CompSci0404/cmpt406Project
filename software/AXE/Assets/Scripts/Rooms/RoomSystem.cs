using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    bool isClear = false;

    List<Transform> doors;

    [SerializeField]
    Transform doorParent;

    public AudioClip newTrack;

    private MusicManager MManager;

    // Start is called before the first frame update
    void Start()
    {
        doors = new List<Transform>();

        for (int i = 0; i < doorParent.childCount; i++)
        {
            Transform door = doorParent.GetChild(i);

            if (door.childCount > 0)
            {
                doors.Add(door.GetChild(0));
            }
        }

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
            foreach (Transform door in doors)
            {
                door.gameObject.SetActive(false);
            }
        }
        ChangeTrack();
    }

    void RoomClear()
    {
        isClear = true;
        foreach (Transform door in doors)
        {
            door.gameObject.SetActive(true);
        }
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
