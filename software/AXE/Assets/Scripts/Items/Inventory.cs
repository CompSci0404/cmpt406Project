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
        leftAvail = true;
        rightAvail = true;
        downAvail = true;
        playerRB = GetComponent<Rigidbody2D>();
        
        myPosition = gameObject.transform;
    }
    public void Update()
    {
        curDPad = GetComponentInParent<MainControls>().getDPadLastPos();
    }
    public void PickUpItem()
    {
        // get all item in range for pickup

        Collider2D[] ItemsInRange = Physics2D.OverlapCircleAll(myPosition.position, 1);
        for (int i = 0; i < ItemsInRange.Length; i++)
        {
            
            if (ItemsInRange[i].CompareTag("Item"))
            {
                // check if a dpad direction is empty
                // if it is pick up item and add it to inventory UI
                // also change name to prevent repetitive adition of clone in name
                // then make dpad button not available
                //Debug.Log(ItemsInRange.Length);
                
                if (curDPad == "up")
                {
                    if (upAvail)
                    {
                        GameObject UP = Instantiate(ItemsInRange[i].gameObject, upItem.transform, false);
                        UP.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        upAvail = false;
                        break;

                    }
                    else
                    {
                        GameObject droppedUP = Instantiate(upItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedUP.name = upItem.transform.GetChild(0).gameObject.name;
                        Destroy(upItem.transform.GetChild(0).gameObject);
                        GameObject UP = Instantiate(ItemsInRange[i].gameObject, upItem.transform, false);
                        UP.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }

                }
                else if (curDPad == "left")
                {
                    if (leftAvail)
                    {
                        GameObject Left = Instantiate(ItemsInRange[i].gameObject, leftItem.transform, false);
                        Left.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        leftAvail = false;
                        break;
                    }
                    else
                    {
                        GameObject droppedLeft = Instantiate(leftItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedLeft.name = leftItem.transform.GetChild(0).gameObject.name;
                        Destroy(leftItem.transform.GetChild(0).gameObject);
                        GameObject Left = Instantiate(ItemsInRange[i].gameObject, leftItem.transform, false);
                        Left.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                }
                else if (curDPad == "right")
                {
                    if (rightAvail)
                    {
                        GameObject Right = Instantiate(ItemsInRange[i].gameObject, rightItem.transform, false);
                        Right.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        rightAvail = false;
                        break;
                    }
                    else
                    {
                        GameObject droppedRight = Instantiate(rightItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedRight.name = rightItem.transform.GetChild(0).gameObject.name;
                        Destroy(rightItem.transform.GetChild(0).gameObject);
                        GameObject Right = Instantiate(ItemsInRange[i].gameObject, rightItem.transform, false);
                        Right.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                }
                else if (curDPad == "down")
                {
                    if (downAvail)
                    {
                        GameObject Down = Instantiate(ItemsInRange[i].gameObject, downItem.transform, false);
                        Down.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        downAvail = false;
                        break;
                    }
                    else
                    {
                        GameObject droppedDown = Instantiate(downItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedDown.name = downItem.transform.GetChild(0).gameObject.name;
                        Destroy(downItem.transform.GetChild(0).gameObject);
                        GameObject Down = Instantiate(ItemsInRange[i].gameObject, downItem.transform, false);
                        Down.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                }
                
            }
        }
    }

    public GameObject getUpItem()
    {
        return upItem;
    }
    public GameObject getLeftItem()
    {
        return leftItem;
    }
    public GameObject getRightItem()
    {
        return rightItem;
    }
    public GameObject getDownItem()
    {
        return downItem;
    }

    public void setUpAvail(bool b)
    {
        upAvail = b;
    }
    public void setLeftAvail(bool b)
    {
        leftAvail = b;
    }
    public void setRightAvail(bool b)
    {
        rightAvail = b;
    }
    public void setDownAvail(bool b)
    {
        downAvail = b;
    }

}
