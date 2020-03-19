using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : ItemClass
{ 
    private GameObject playerCont;

    private PlayerStats stats;

    [SerializeField]
    private GameObject DoubleDamageSprite;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = DoubleDamage;
        playerCont = GameObject.FindWithTag("Player");
        stats = playerCont.GetComponentInChildren<PlayerStats>();
    }

    void DoubleDamage()
    {
        stats.SetDamage(stats.GetDamage() * 2);
        DoubleDamageSprite.SetActive(true);
        Debug.Log("I AM A STRONG BOI!!!");
        Invoke("RevertDamage", 10);
    }

    void RevertDamage()
    {
        stats.SetDamage(stats.GetDamage() / 2);
        DoubleDamageSprite.SetActive(false);

    }


}
