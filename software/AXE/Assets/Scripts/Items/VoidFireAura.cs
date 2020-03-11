using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFireAura : ItemClass
{
    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UseVoidFireAura;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
        setAbilityCooldown(0);
    }

    public void UseVoidFireAura()
    {
        // make sure we have the right player stat
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }

        // ability indicator
        GameObject aura = Instantiate((GameObject)Resources.Load("Ability/VoidFireAuraIndicator"), playerRB.transform.position, Quaternion.identity) as GameObject;
        aura.transform.localPosition = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y, 0);
    }



}
