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

    private Transform myPosition;
    private Rigidbody2D playerRB;

    private string curDPad;
    // inventory position on DPad
    // 0 = Up
    // 1 = Left
    // 2 = Right
    // 3 = Down

    // check for swap abilities
    private GameObject swapAbility;
    private void Start()
    {
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
                    if (isUpItem())
                    {
                        GameObject UP = Instantiate(ItemsInRange[i].gameObject, upItem.transform, false);
                        UP.transform.localPosition = new Vector3(-0.04f, 0.065f, 0f);
                        UP.name = ItemsInRange[i].gameObject.name;
                        //handleIfSwap(ItemsInRange[i].gameObject, UP);
                        Destroy(ItemsInRange[i].gameObject);
                        break;

                    }
                    else
                    {
                        if (!upItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        {
                            break;
                        }
                        GameObject droppedUP = Instantiate(upItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedUP.name = upItem.transform.GetChild(0).gameObject.name;
                        Destroy(upItem.transform.GetChild(0).gameObject);
                        GameObject UP = Instantiate(ItemsInRange[i].gameObject, upItem.transform, false);
                        UP.transform.localPosition = new Vector3(0f, 0.065f, 0f);
                        UP.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }

                }
                else if (curDPad == "left")
                {
                    if (isLeftItem())
                    {
                        GameObject Left = Instantiate(ItemsInRange[i].gameObject, leftItem.transform, false);
                        Left.transform.localPosition = new Vector3(0f, 0.065f, 0f);
                        Left.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                    else
                    {
                        if (!leftItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        {
                            break;
                        }
                        GameObject droppedLeft = Instantiate(leftItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedLeft.name = leftItem.transform.GetChild(0).gameObject.name;
                        Destroy(leftItem.transform.GetChild(0).gameObject);
                        GameObject Left = Instantiate(ItemsInRange[i].gameObject, leftItem.transform, false);
                        Left.transform.localPosition = new Vector3(0f, 0.065f, 0f);
                        Left.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                }
                else if (curDPad == "right")
                {
                    if (isRightItem())
                    {
                        GameObject Right = Instantiate(ItemsInRange[i].gameObject, rightItem.transform, false);
                        Right.transform.localPosition = new Vector3(0f, 0.065f, 0f);
                        Right.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                    else
                    {
                        if (!rightItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        {
                            break;
                        }
                        GameObject droppedRight = Instantiate(rightItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedRight.name = rightItem.transform.GetChild(0).gameObject.name;
                        Destroy(rightItem.transform.GetChild(0).gameObject);
                        GameObject Right = Instantiate(ItemsInRange[i].gameObject, rightItem.transform, false);
                        Right.transform.localPosition = new Vector3(0f, 0.065f, 0f);
                        Right.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                }
                else if (curDPad == "down")
                {
                    if (isDownItem())
                    {
                        GameObject Down = Instantiate(ItemsInRange[i].gameObject, downItem.transform, false);
                        Down.transform.localPosition = new Vector3(-0.06f, 0.065f, 0f);
                        Down.name = ItemsInRange[i].gameObject.name;
                        Destroy(ItemsInRange[i].gameObject);
                        break;
                    }
                    else
                    {
                        if (!downItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        {
                            break;
                        }
                        GameObject droppedDown = Instantiate(downItem.transform.GetChild(0).gameObject, playerRB.position, Quaternion.identity);
                        droppedDown.name = downItem.transform.GetChild(0).gameObject.name;
                        Destroy(downItem.transform.GetChild(0).gameObject);
                        GameObject Down = Instantiate(ItemsInRange[i].gameObject, downItem.transform, false);
                        Down.transform.localPosition = new Vector3(-0.06f, 0.065f, 0f);
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

    public bool isUpItem()
    {
        if (upItem.GetComponentInChildren<ItemClass>() == null)
        {
            Debug.Log("Up avail");
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isLeftItem()
    {
        if (leftItem.GetComponentInChildren<ItemClass>() == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isRightItem()
    {
        if (rightItem.GetComponentInChildren<ItemClass>() == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isDownItem()
    {
        if (downItem.GetComponentInChildren<ItemClass>() == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void handleIfSwap(GameObject swapAb, GameObject DPadPos)
    {
        if (swapAb.GetComponent<ItemClass>().myItemType == ItemClass.ItemType.swapAbility)
        {
            swapAbility = DPadPos;
        }
    }

}
