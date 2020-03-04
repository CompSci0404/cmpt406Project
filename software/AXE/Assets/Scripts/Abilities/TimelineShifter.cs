using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The character who is swapped activates a powerful device which explores every possible timeline, 
/// and shifts the player to timelines in which each attack coming their way is avoided until its anti-matter fuel runs out. 
/// (player is invincible for a limited period of time)
/// </summary>
public class TimelineShifter : ItemClass
{
    private GameObject timelineShifter;

    private GameObject playerCont;

    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = MakeInvulnerable;
        timelineShifter = this.gameObject;
        playerCont = GameObject.FindWithTag("Player");
        stats = playerCont.GetComponentInChildren<PlayerStats>();
    }

    void MakeInvulnerable()
    {
        stats.MakeInvincible();
        Invoke("StopInvicibility", 3);
    }

    void StopInvincibility()
    {
        stats.ResetInvincibility();
    }
}
