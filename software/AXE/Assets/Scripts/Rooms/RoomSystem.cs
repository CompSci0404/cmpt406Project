using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    bool isClear = false;

    [SerializeField]
    Transform doorParent;

    [SerializeField]
    GameObject Player;

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
        if (MManager.currentMusic.clip.name != newTrack.name)
        {
            ChangeTrack();
        }
    }

    void RoomClear()
    {
        isClear = true;
        for (int i = 0; i < doorParent.childCount; i++)
        {
            Transform door = doorParent.GetChild(i);
            door.SendMessage("TurnOn");
            if(Player.GetComponent<Abilities>().GetActiveAbility() != null)
            {
                Player.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().ReduceAbilityCooldown();
            }
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
