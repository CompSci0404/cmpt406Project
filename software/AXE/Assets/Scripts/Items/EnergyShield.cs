using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A shield of barely contained transparent energy enveloping the user; blocks one blow then detonates pushing back any nearby enemies.
/// </summary>
public class EnergyShield : ItemClass
{
    float radius = 0.8f;

    private GameObject energyShield;

    private GameObject playerCont;

    private PlayerStats stats;


    [SerializeField]
    private GameObject ShieldSprite;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = SpawnShield;
        energyShield = this.gameObject;
        playerCont = GameObject.FindWithTag("Player");
        stats = playerCont.GetComponentInChildren<PlayerStats>();
    }

    void SpawnShield()
    {
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        stats.MakeInvincible();
        ShieldSprite.SetActive(true);
        Invoke("FadeShield", 10);
    }

    void FadeShield()
    {
        ShieldSprite.SetActive(false);
        stats.ResetInvincibility();
    }

}
