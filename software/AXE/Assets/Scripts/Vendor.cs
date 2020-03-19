using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    private GameObject playerCont;

    private PlayerStats stats;

    [SerializeField] GameObject vendorUI;


    [SerializeField] List<GameObject> thingsOnSale;



    // Start is called before the first frame update
    void Start()
    {
        playerCont = GameObject.FindWithTag("Player");
        //vendorUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }


    }

    public void VendorInteract()
    {
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //vendorUI.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // vendorUI.SetActive(false);
        }
    }


}
