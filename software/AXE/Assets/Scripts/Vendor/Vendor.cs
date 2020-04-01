using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    private GameObject playerCont;

    private PlayerStats stats;

    [SerializeField] private int refreshPrice;

    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GameObject.FindWithTag("Player");
        //vendorUI.SetActive(false);
    }

    public void VendorInteract()
    {
        if (playerInRange)
        {
            BuyRefresh();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public bool GetPlayerInRangeVendor()
    {
        return playerInRange;
    }

    public void BuyRefresh()
    {
        GameObject playerCont = GameObject.FindWithTag("Player");
        CoinStats stats;
        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            stats = playerCont.GetComponent<CoinStats>();
            if (refreshPrice <= stats.GetThorCoins())
            {
                stats.UseThorCoins(refreshPrice);
                for (int i = 0; i < 4; i++)
                {
                    this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i).GetComponent<VendorItemsSpawn>().Refresh();
                    Debug.Log(this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i));
                }
            }
        }
        else
        {
            stats = playerCont.GetComponent<CoinStats>();
            if (refreshPrice <= stats.GetValkCoins())
            {
                stats.UseValkCoins(refreshPrice);
                for (int i = 0; i < 4; i++)
                {
                    this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i).GetComponent<VendorItemsSpawn>().Refresh();
                    Debug.Log(this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i));
                }
            }
        }
        // refresh the items

    }
}
