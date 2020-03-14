﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that will check your current abilites and swap them out (much like the inventory system)
/// </summary>
public class Abilities : MonoBehaviour
{
    // UI ability location 
    [SerializeField]
    private GameObject aAbility;
    [SerializeField]
    private GameObject swapAbility;

    public bool aAvailable;
    public bool swapAvailable;

    // going to be "A", or "Swap" 
    public string abilitySlot;

    private Transform position;
    private Rigidbody2D rBody;

    private MainControls controls;

    public GameObject EnergyShield;
    public GameObject GodLaser;
    public GameObject PlasmaHammer;
    public GameObject ClusterBomb;
    public GameObject TimelineShifter;

    private GameObject CurrentA;
    private GameObject CurrentSwap;


    // Start is called before the first frame update
    void Start()
    {
        aAvailable = true;
        swapAvailable = true;

        position = gameObject.transform;

        rBody = GetComponent<Rigidbody2D>();

        controls = GetComponent<MainControls>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickUpAbility()
    {
        // get all abilities in range for pickup
        Collider2D[] AbilitiesInRange = Physics2D.OverlapCircleAll(position.position, 1);
        for (int i = 0; i < AbilitiesInRange.Length; i++)
        {
            if (AbilitiesInRange[i].CompareTag("Ability"))
            {
                // every item starts as GetNeedCoin false
                // if vendor spawn the item getNeedcoin is true
                // so you have to buy it but once you bought it needCoin is false
                if (AbilitiesInRange[i].GetComponent<ItemClass>().GetNeedCoin())
                {
                    AbilitiesInRange[i].GetComponent<ItemClass>().BuyItem();
                }
                // second time checking if item was bought if not then cant pick it up
                if (AbilitiesInRange[i].GetComponent<ItemClass>().GetNeedCoin())
                {
                    break;
                }

                // check if a button is empty
                // if it is pick up ability and add it to ability UI
                // disable button (for now)

                abilitySlot = "A";

                if (aAvailable)
                {
                    if (AbilitiesInRange[i].GetComponent<EnergyShield>())
                    {
                        EnergyShield = GameObject.Find("ES_UI");
                        EnergyShield.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<GodLaser>())
                    {
                        GodLaser = GameObject.Find("GL_UI");
                        GodLaser.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<PlasmaHammer>())
                    {
                        PlasmaHammer = GameObject.Find("PH_UI");
                        PlasmaHammer.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<VoidFireAura>())
                    {
                        PlasmaHammer = GameObject.Find("PH_UI");
                        PlasmaHammer.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }

                    //GameObject A = Instantiate(AbilitiesInRange[i].gameObject, aAbility.transform, false);
                    //A.transform.localPosition = new Vector3(0.033f, -0.025f, -1f);
                    //Vector3 scaleChange = new Vector3(-0.1f, -0.1f, 0f);
                    //A.transform.localScale += scaleChange;
                    //A.name = AbilitiesInRange[i].gameObject.name;
                    //Destroy(AbilitiesInRange[i].gameObject);
                    aAvailable = false;
                    break;
                }
                else
                {
                    // check our current item
                    if (CurrentA.GetComponent<EnergyShield>())
                    {
                        //remove from UI
                        EnergyShield.GetComponent<Renderer>().sortingOrder = -1;
                        CurrentA.transform.position = new Vector2(rBody.transform.position.x, rBody.transform.position.y-1);
                    }
                    else if (CurrentA.GetComponent<GodLaser>())
                    {
                        //remove from UI
                        GodLaser.GetComponent<Renderer>().sortingOrder = -1;
                        CurrentA.transform.position = new Vector2(rBody.transform.position.x, rBody.transform.position.y - 1);
                    }
                    else if (CurrentA.GetComponent<PlasmaHammer>())
                    {
                        //remove from UI
                        PlasmaHammer.GetComponent<Renderer>().sortingOrder = -1;
                        CurrentA.transform.position = new Vector2(rBody.transform.position.x, rBody.transform.position.y - 1);
                    }

                    // Pick up new item
                    if (AbilitiesInRange[i].GetComponent<EnergyShield>())
                    {
                        EnergyShield = GameObject.Find("ES_UI");
                        EnergyShield.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<GodLaser>())
                    {
                        GodLaser = GameObject.Find("GL_UI");
                        GodLaser.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<PlasmaHammer>())
                    {
                        PlasmaHammer = GameObject.Find("PH_UI");
                        PlasmaHammer.GetComponent<Renderer>().sortingOrder = 1;
                        aAbility = AbilitiesInRange[i].gameObject;
                        CurrentA = AbilitiesInRange[i].gameObject;
                        CurrentA.transform.position = new Vector2(0, -1000);
                    }


                    //// removed 'rBody.position =' before new Vecotr2(rBody.pos... in dropA second param
                    //GameObject dropA = Instantiate(aAbility.transform.GetChild(0).gameObject,
                    //new Vector2(rBody.position.x + 0.5f, rBody.position.y + -0.5f) ,Quaternion.identity);

                    //// changes
                    //Vector3 scaleChange = new Vector3(-0.2f, -0.2f, 0f);
                    //dropA.transform.localScale -= scaleChange;
                    ////

                    //dropA.name = aAbility.transform.GetChild(0).gameObject.name;
                    //Destroy(aAbility.transform.GetChild(0).gameObject);
                    //GameObject A = Instantiate(AbilitiesInRange[i].gameObject, aAbility.transform, false);

                    //// changes
                    //A.transform.localPosition = new Vector3(0.033f, -0.025f, -1f);
                    //A.transform.localScale += scaleChange;
                    ////

                    //A.name = AbilitiesInRange[i].gameObject.name;
                    //Destroy(AbilitiesInRange[i].gameObject);
                    break;
                }
            }

            else if (AbilitiesInRange[i].CompareTag("SwapAbility"))
            {
                // every item starts as GetNeedCoin false
                // if vendor spawn the item getNeedcoin is true
                // so you have to buy it but once you bought it needCoin is false
                if (AbilitiesInRange[i].GetComponent<ItemClass>().GetNeedCoin())
                {
                    AbilitiesInRange[i].GetComponent<ItemClass>().BuyItem();
                }
                // second time checking if item was bought if not then cant pick it up
                if (AbilitiesInRange[i].GetComponent<ItemClass>().GetNeedCoin())
                {
                    break;
                }

                abilitySlot = "Swap";

                if (swapAvailable)
                {
                    if (AbilitiesInRange[i].GetComponent<ClusterBomb>())
                    {
                        ClusterBomb = GameObject.Find("CB_UI");
                        ClusterBomb.GetComponent<Renderer>().sortingOrder = 1;
                        swapAbility = AbilitiesInRange[i].gameObject;
                        CurrentSwap = AbilitiesInRange[i].gameObject;
                        CurrentSwap.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<TimelineShifter>())
                    {
                        TimelineShifter = GameObject.Find("TS_UI");
                        TimelineShifter.GetComponent<Renderer>().sortingOrder = 1;
                        swapAbility = AbilitiesInRange[i].gameObject;
                        CurrentSwap = AbilitiesInRange[i].gameObject;
                        CurrentSwap.transform.position = new Vector2(0, -1000);
                    }

                    //GameObject Swap = Instantiate(AbilitiesInRange[i].gameObject, swapAbility.transform, false);
                    //Swap.transform.localPosition = new Vector3(0.046f, -0.029f, 0f);
                    //Vector3 scaleChange = new Vector3(-0.1f, -0.1f, 0f);
                    //Swap.transform.localScale += scaleChange;
                    //Swap.name = AbilitiesInRange[i].gameObject.name;
                    //Destroy(AbilitiesInRange[i].gameObject);
                    swapAvailable = false;
                    controls.swapAbility = "YES";
                    break;
                }
                else
                {
                    // check our current item
                    if (CurrentSwap.GetComponent<ClusterBomb>())
                    {
                        //remove from UI
                        ClusterBomb.GetComponent<Renderer>().sortingOrder = -1;
                        CurrentSwap.transform.position = new Vector2(rBody.transform.position.x, rBody.transform.position.y - 1);
                    }
                    else if (CurrentSwap.GetComponent<TimelineShifter>())
                    {
                        //remove from UI
                        TimelineShifter.GetComponent<Renderer>().sortingOrder = -1;
                        CurrentSwap.transform.position = new Vector2(rBody.transform.position.x, rBody.transform.position.y - 1);
                    }

                    // pick up new item
                    if (AbilitiesInRange[i].GetComponent<ClusterBomb>())
                    {
                        ClusterBomb = GameObject.Find("CB_UI");
                        ClusterBomb.GetComponent<Renderer>().sortingOrder = 1;
                        swapAbility = AbilitiesInRange[i].gameObject;
                        CurrentSwap = AbilitiesInRange[i].gameObject;
                        CurrentSwap.transform.position = new Vector2(0, -1000);
                    }
                    else if (AbilitiesInRange[i].GetComponent<TimelineShifter>())
                    {
                        TimelineShifter = GameObject.Find("TS_UI");
                        TimelineShifter.GetComponent<Renderer>().sortingOrder = 1;
                        swapAbility = AbilitiesInRange[i].gameObject;
                        CurrentSwap = AbilitiesInRange[i].gameObject;
                        CurrentSwap.transform.position = new Vector2(0, -1000);
                    }

                    ////rBody.position = new Vector2(rBody.position.x + 1, rBody.position.y + 1);
                    //// removed 'rBody.position =' before new Vecotr2(rBody.pos... in dropSwap second param
                    //GameObject dropSwap = Instantiate(swapAbility.transform.GetChild(0).gameObject, 
                    //new Vector2(rBody.position.x + 0.5f, rBody.position.y + -0.5f), Quaternion.identity);

                    //// changes
                    //Vector3 scaleChange = new Vector3(-0.1f, -0.1f, 0f);
                    //dropSwap.transform.localScale -= scaleChange;
                    ////

                    //dropSwap.name = swapAbility.transform.GetChild(0).gameObject.name;
                    //Destroy(swapAbility.transform.GetChild(0).gameObject);
                    //GameObject Swap = Instantiate(AbilitiesInRange[i].gameObject, swapAbility.transform, false);

                    //// changes
                    //Swap.transform.localPosition = new Vector3(0.033f, -0.025f, -1f);
                    //Swap.transform.localScale += scaleChange;
                    ////

                    //Swap.name = AbilitiesInRange[i].gameObject.name;
                    //Destroy(AbilitiesInRange[i].gameObject);
                    break;
                }
            }
        }
    }

    public GameObject GetActiveAbility()
    {
        return aAbility;
    }

    public GameObject GetSwapAbility()
    {
        return swapAbility;
    }

    public bool isAbility()
    {
        return aAbility.GetComponentInChildren<ItemClass>() != null;
    }

    public Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public float AngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

}