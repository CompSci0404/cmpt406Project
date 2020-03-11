using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaHammer : ItemClass
{

    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;
    private PlayerStats stats;

    private Vector2 lookDirection;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UsePlasmaHammer;
        playerCont = GameObject.FindWithTag("Player");
        setHasIndicator(true);
        playerRB = playerCont.GetComponent<Rigidbody2D>();
    }
    public void UsePlasmaHammer()
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

        // box collider 2D Version
        angle = playerCont.GetComponent<MainControls>().getRSAngle();
        lookDirection = playerCont.GetComponent<MainControls>().getRSDirection();
        // ability indicator
        GameObject laser = Instantiate((GameObject)Resources.Load("PlasmaHammerIndicator"), playerRB.transform.position, Quaternion.Euler(0, 0, angle)) as GameObject;

        // remove the particle effect indicator
        StartCoroutine(deleteEffects(laser));
    }

    IEnumerator deleteEffects(GameObject effect)
    {
        yield return new WaitForSeconds(1f);
        Destroy(effect);
    }

}
