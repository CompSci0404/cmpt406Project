using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // UI item location also where it is stored 
    [SerializeField] private GameObject upItem;
    [SerializeField] private GameObject leftItem;
    [SerializeField] private GameObject rightItem;
    [SerializeField] private GameObject downItem;
    private bool upAvail;
    private bool leftAvail;
    private bool rightAvail;
    private bool downAvail;

    private Transform myPosition;
    private Rigidbody2D playerRB;

    private string curDPad;
    // inventory position on DPad
    // 0 = Up
    // 1 = Left
    // 2 = Right
    // 3 = Down
    private void Start()
    {
        upAvail = true;
        playerRB = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        curDPad = GetComponentInParent<MainControls>().getDPadLastPos();
        myPosition = gameObject.transform;
    }
    public void PickUpItem()
    {
        Collider2D[] ItemsInRange = Physics2D.OverlapCircleAll(myPosition.position, 1);
        for (int i = 0; i < ItemsInRange.Length; i++)
        {
            if (ItemsInRange[i].CompareTag("Item"))
            {
                if (curDPad == "up")
                {
                    if (upAvail)
                    {
                        GameObject UP = Instantiate(ItemsInRange[i].gameObject, upItem.transform, false);
                        UP.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        upAvail = false;
                    }
                    else
                    {
                        GameObject droppedUP = Instantiate(upItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedUP.name = upItem.transform.GetChild(0).gameObject.name;
                        Destroy(upItem.transform.GetChild(0).gameObject);
                        GameObject UP = Instantiate(ItemsInRange[i].gameObject, upItem.transform, false);
                        UP.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                    }
                    
                }
                else if (curDPad == "left")
                {
                    Instantiate(ItemsInRange[i].gameObject, leftItem.transform, false);
                    Destroy(ItemsInRange[i].gameObject);
                }
                else if (curDPad == "right")
                {
                    Instantiate(ItemsInRange[i].gameObject, rightItem.transform, false);
                    Destroy(ItemsInRange[i].gameObject);
                }
                else if (curDPad == "down")
                {
                    Instantiate(ItemsInRange[i].gameObject, downItem.transform, false);
                    Destroy(ItemsInRange[i].gameObject);
                }
                
            }
        }
    }

}
