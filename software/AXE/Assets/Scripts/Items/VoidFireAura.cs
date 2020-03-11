using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFireAura : ItemClass
{
    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;

    private GameObject aura;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UseVoidFireAura;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
        setAbilityCooldown(0);
        SetHasDot(true);
        SetDoDot(true);

    }
    private void Update()
    {
        if (aura != null)
        {
            aura.transform.localPosition = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y, 0);
        }
        
    }


    public void UseVoidFireAura()
    {
        // ability indicator
        if (GetDoDot())
        {
            aura = Instantiate((GameObject)Resources.Load("Ability/VoidFireAuraIndicator"), playerRB.transform.position, Quaternion.identity) as GameObject;
            SetDoDot(false);
        }
    }
}
