using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerStats stats;
    GameObject parent;

    // Start is called before the first frame update
    void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        parent = transform.parent.gameObject;
        parent.SendMessage("UpdateStats", stats);
    }
}
