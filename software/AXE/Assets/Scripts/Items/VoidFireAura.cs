using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFireAura : ItemClass
{
    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;

    private int playerUsed;

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
            
            if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1 && playerUsed == 2)
            {
                aura.transform.localPosition = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y + 1000, 0);
            }
            else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2 && playerUsed == 1)
            {
                aura.transform.localPosition = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y + 1000, 0);
            }
            else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1 && playerUsed == 1)
            {
                aura.transform.localPosition = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y, 0);
            }
            else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2 && playerUsed == 2)
            {
                aura.transform.localPosition = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y, 0);
            }
        }

        
    }


    public void UseVoidFireAura()
    {
        // ability indicator
        if (GetDoDot())
        {
            if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
            {
                playerUsed = 1;
            }
            else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2)
            {
                playerUsed = 2;
            }
            aura = Instantiate((GameObject)Resources.Load("Prefabs/VoidFireAuraIndicator"), playerRB.transform.position, Quaternion.identity) as GameObject;
            SetDoDot(false);
        }
    }
}
