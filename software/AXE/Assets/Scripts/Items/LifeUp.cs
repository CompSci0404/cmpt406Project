using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : ItemClass
{
    private PlayerStats stats;

    private bool used = false;

    private GameObject playerCont;
    // Start is called before the first frame update
    void Start()
    {
        itemEffect = AddLife;
        playerCont = GameObject.FindWithTag("Player");
        stats = playerCont.GetComponent<PlayerStats>();
        SetUsable(true);
    }


    public void AddLife()
    {
        //SoundEffect
        FindObjectOfType<AudioManager>().PlaySound("itemConsumed");

        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            playerCont = GameObject.FindWithTag("Thor");
        }
        else
        {
            playerCont = GameObject.FindWithTag("Type2");
        }

        playerCont = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject;
        stats = playerCont.GetComponent<PlayerStats>();
        if (stats.GetLives() < 10)
        {
            GameObject.Find("LivesHUD").GetComponent<LiveCounter>().SetAddLife();
        }
    }
}
