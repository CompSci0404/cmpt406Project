using System;
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
                    break;
                }
            }

            else if (AbilitiesInRange[i].CompareTag("SwapAbility"))
            {
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

    public bool IsAbility()
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