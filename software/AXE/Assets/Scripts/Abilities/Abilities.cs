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
    private GameObject xAbility;
    [SerializeField]
    private GameObject swapAbility;

    private bool aAvailable;
    private bool xAvailable;
    private bool swapAvailable;

    // going to be "A", "X", or "Swap" 
    public string abilitySlot;
   
    private Transform position;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        aAvailable = true;
        xAvailable = true;
        swapAvailable = true;

        position = gameObject.transform;
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
                Debug.Log(AbilitiesInRange.Length);
                
                if (abilitySlot == "A")
                {
                    if (aAvailable)
                    {
                        GameObject A = Instantiate(AbilitiesInRange[i].gameObject, aAbility.transform, false);
                        A.name = AbilitiesInRange[i].gameObject.name;
                        Destroy(AbilitiesInRange[i].gameObject);
                        aAvailable = false;
                        break;

                    }
                    else
                    {
                        GameObject dropA = Instantiate(aAbility.transform.GetChild(0).gameObject, rBody.position, Quaternion.identity);
                        dropA.name = aAbility.transform.GetChild(0).gameObject.name;
                        Destroy(aAbility.transform.GetChild(0).gameObject);
                        GameObject A = Instantiate(AbilitiesInRange[i].gameObject, aAbility.transform, false);
                        A.name = AbilitiesInRange[i].gameObject.name;
                        Destroy(AbilitiesInRange[i].gameObject);
                        break;
                    }
                }
                //if (abilitySlot == "X")
                //{
                //    if (xAvailable)
                //    {
                //        GameObject X = Instantiate(AbilitiesInRange[i].gameObject, xAbility.transform, false);
                //        X.name = AbilitiesInRange[i].gameObject.name;
                //        Destroy(AbilitiesInRange[i].gameObject);
                //        xAvailable = false;
                //        break;

                //    }
                //    else
                //    {
                //        GameObject dropX = Instantiate(xAbility.transform.GetChild(0).gameObject, rBody.position, Quaternion.identity);
                //        dropX.name = xAbility.transform.GetChild(0).gameObject.name;
                //        Destroy(xAbility.transform.GetChild(0).gameObject);
                //        GameObject X = Instantiate(AbilitiesInRange[i].gameObject, xAbility.transform, false);
                //        X.name = AbilitiesInRange[i].gameObject.name;
                //        Destroy(AbilitiesInRange[i].gameObject);
                //        break;
                //    }
                //}
                if (abilitySlot == "Swap")
                {
                    if(swapAvailable)
                    {
                        GameObject Swap = Instantiate(AbilitiesInRange[i].gameObject, swapAbility.transform, false);
                        Swap.name = AbilitiesInRange[i].gameObject.name;
                        Destroy(AbilitiesInRange[i].gameObject);
                        swapAvailable = false;
                        break;

                    }
                    else
                    {
                        GameObject dropSwap = Instantiate(swapAbility.transform.GetChild(0).gameObject, rBody.position, Quaternion.identity);
                        dropSwap.name = swapAbility.transform.GetChild(0).gameObject.name;
                        Destroy(swapAbility.transform.GetChild(0).gameObject);
                        GameObject Swap = Instantiate(AbilitiesInRange[i].gameObject, swapAbility.transform, false);
                        Swap.name = AbilitiesInRange[i].gameObject.name;
                        Destroy(AbilitiesInRange[i].gameObject);
                        break;
                }
                }
            }
        }
    }
    public GameObject getaAbility()
    {
        return aAbility;
    }
    public GameObject getxAbility()
    {
        return xAbility;
    }
}
