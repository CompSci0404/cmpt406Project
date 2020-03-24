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
        SetHasIndicator(true);
        playerRB = playerCont.GetComponent<Rigidbody2D>();
    }
    public void UsePlasmaHammer()
    {
        // make sure we have the right player stat
        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }

        // box collider 2D Version
        angle = playerCont.GetComponent<MainControls>().GetRSAngle();
        lookDirection = playerCont.GetComponent<MainControls>().GetRSDirection();

        // ability indicator
        GameObject indicator = Resources.Load("Prefabs/PlasmaHammerIndicator", typeof(GameObject)) as GameObject;
        if (null != indicator)
        {
            GameObject laser = Instantiate(indicator, playerRB.transform.position, Quaternion.Euler(0, 0, angle));

            // remove the particle effect indicator
            StartCoroutine(DeleteEffects(laser));
        }
        else
        {
            Debug.LogError("Unable to load Prefabs/PlasmaHammerIndicator.prefab from Resources");
        }
    }

    IEnumerator DeleteEffects(GameObject effect)
    {
        yield return new WaitForSeconds(1f);
        Destroy(effect);
    }

}
