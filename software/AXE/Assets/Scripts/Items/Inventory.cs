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

    private GameObject upItemTemp;
    private GameObject leftItemTemp;
    private GameObject rightItemTemp;
    private GameObject downItemTemp;

    private bool upItemUsed;
    private bool leftItemUsed;
    private bool rightItemUsed;
    private bool downItemUsed;

    private GameObject OdinAle;
    private GameObject BatteryBread;
    private GameObject SwiftSauce;
    private GameObject LifeUp;

    private GameObject CurrentUp;
    private GameObject CurrentLeft;
    private GameObject CurrentRight;
    private GameObject CurrentDown;

    private bool isUp;
    private bool isDown;
    private bool isLeft;
    private bool isRight;

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
        isUp = true;
        isDown = true;
        isRight = true;
        isLeft = true;
    }
    public void Update()
    {
        curDPad = GetComponentInParent<MainControls>().GetDPadLastPos();

        if (upItemUsed && CurrentUp != null)
        {
            if (CurrentUp.GetComponent<OdinAle>())
            {
                //remove from UI
                OdinAle.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentUp.GetComponent<BatteryBread>())
            {
                //remove from UI
                BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentUp.GetComponent<SwiftSauce>())
            {
                //remove from UI
                SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentUp.GetComponent<LifeUp>())
            {
                //remove from UI
                LifeUp.GetComponent<Renderer>().sortingOrder = -1;
            }
            upItemUsed = false;
        }
        if (leftItemUsed && CurrentLeft != null)
        {
            if (CurrentLeft.GetComponent<OdinAle>())
            {
                //remove from UI
                OdinAle.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentLeft.GetComponent<BatteryBread>())
            {
                //remove from UI
                BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentLeft.GetComponent<SwiftSauce>())
            {
                //remove from UI
                SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentUp.GetComponent<LifeUp>())
            {
                //remove from UI
                LifeUp.GetComponent<Renderer>().sortingOrder = -1;
            }
            leftItemUsed = false;
        }
        if (rightItemUsed && CurrentRight != null)
        {
            if (CurrentRight.GetComponent<OdinAle>())
            {
                //remove from UI
                OdinAle.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentRight.GetComponent<BatteryBread>())
            {
                //remove from UI
                BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentRight.GetComponent<SwiftSauce>())
            {
                //remove from UI
                SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentUp.GetComponent<LifeUp>())
            {
                //remove from UI
                LifeUp.GetComponent<Renderer>().sortingOrder = -1;
            }
            rightItemUsed = false;
        }
        if (downItemUsed && CurrentRight != null)
        {
            if (CurrentDown.GetComponent<OdinAle>())
            {
                //remove from UI
                OdinAle.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentDown.GetComponent<BatteryBread>())
            {
                //remove from UI
                BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentDown.GetComponent<SwiftSauce>())
            {
                //remove from UI
                SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
            }
            else if (CurrentUp.GetComponent<LifeUp>())
            {
                //remove from UI
                LifeUp.GetComponent<Renderer>().sortingOrder = -1;
            }
            downItemUsed = false;
        }
    }
    public void PickUpItem()
    {
        // get all item in range for pickup
        Collider2D[] ItemsInRange = Physics2D.OverlapCircleAll(myPosition.position, 1);
        for (int i = 0; i < ItemsInRange.Length; i++)
        {
            if (ItemsInRange[i].CompareTag("Item"))
            {
                // every item starts as GetNeedCoin false
                // if vendor spawn the item getNeedcoin is true
                // so you have to buy it but once you bought it needCoin is false
                if (ItemsInRange[i].GetComponent<ItemClass>().GetNeedCoin())
                {
                    ItemsInRange[i].GetComponent<ItemClass>().BuyItem();
                }
                // second time checking if item was bought if not then cant pick it up
                if (ItemsInRange[i].GetComponent<ItemClass>().GetNeedCoin())
                {
                    break;
                }
                // check if a dpad direction is empty
                // if it is pick up item and add it to inventory UI
                // also change name to prevent repetitive adition of clone in name
                // then make dpad button not available
                //Debug.Log(ItemsInRange.Length);
                
                if (curDPad == "up")
                {
                    if (isUp)
                    {
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = upItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = upItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = upItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = upItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        isUp = false;
                        break;
                    }
                    else
                    {
                        //if (!upItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        //{
                        //    break;
                        //}
                        // check our current item
                        if (CurrentUp.GetComponent<OdinAle>())
                        {
                            //remove from UI
                            OdinAle.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentUp.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentUp.GetComponent<BatteryBread>())
                        {
                            //remove from UI
                            BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentUp.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentUp.GetComponent<SwiftSauce>())
                        {
                            //remove from UI
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentUp.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentUp.GetComponent<LifeUp>())
                        {
                            //remove from UI
                            LifeUp.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentUp.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }

                        // Pick up new item
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = upItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = upItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = upItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = upItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            upItemTemp = ItemsInRange[i].gameObject;
                            CurrentUp = ItemsInRange[i].gameObject;
                            CurrentUp.transform.position = new Vector2(0, -1000);
                        }
                    }
                    break;
                }
                else if (curDPad == "left")
                {
                    if (isLeft)
                    {
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = leftItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = leftItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = leftItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = leftItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        isLeft = false;
                        break;
                    }
                    else
                    {
                        //if (!leftItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        //{
                        //    break;
                        //}
                        // check our current item
                        if (CurrentLeft.GetComponent<OdinAle>())
                        {
                            //remove from UI
                            OdinAle.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentLeft.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentLeft.GetComponent<BatteryBread>())
                        {
                            //remove from UI
                            BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentLeft.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentLeft.GetComponent<SwiftSauce>())
                        {
                            //remove from UI
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentLeft.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentLeft.GetComponent<LifeUp>())
                        {
                            //remove from UI
                            LifeUp.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentLeft.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }

                        // Pick up new item
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = leftItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = leftItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = leftItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = leftItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            leftItemTemp = ItemsInRange[i].gameObject;
                            CurrentLeft = ItemsInRange[i].gameObject;
                            CurrentLeft.transform.position = new Vector2(0, -1000);
                        }
                        break;
                    }
                }
                else if (curDPad == "right")
                {
                    if (isRight)
                    {
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = rightItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = rightItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = rightItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = rightItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        isRight = false;
                        break;
                    }
                    else
                    {
                        //if (!rightItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        //{
                        //    break;
                        //}
                        // check our current item
                        if (CurrentRight.GetComponent<OdinAle>())
                        {
                            //remove from UI
                            OdinAle.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentRight.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentRight.GetComponent<BatteryBread>())
                        {
                            //remove from UI
                            BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentRight.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentRight.GetComponent<LifeUp>())
                        {
                            //remove from UI
                            LifeUp.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentRight.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentRight.GetComponent<SwiftSauce>())
                        {
                            //remove from UI
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentRight.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }

                        // Pick up new item
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = rightItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = rightItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = rightItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = rightItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            rightItemTemp = ItemsInRange[i].gameObject;
                            CurrentRight = ItemsInRange[i].gameObject;
                            CurrentRight.transform.position = new Vector2(0, -1000);
                        }
                        break;
                    }
                }
                else if (curDPad == "down")
                {
                    if (isDown)
                    {
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = downItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = downItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = downItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("LU_UI");
                            LifeUp.transform.position = downItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        isDown = false;
                        break;
                    }
                    else
                    {
                        //if (!downItem.transform.GetChild(0).gameObject.GetComponent<ItemClass>().GetUsable())
                        //{
                        //    break;
                        //}
                        // check our current item
                        if (CurrentDown.GetComponent<OdinAle>())
                        {
                            //remove from UI
                            OdinAle.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentDown.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentDown.GetComponent<BatteryBread>())
                        {
                            //remove from UI
                            BatteryBread.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentDown.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentDown.GetComponent<SwiftSauce>())
                        {
                            //remove from UI
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentDown.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }
                        else if (CurrentDown.GetComponent<LifeUp>())
                        {
                            //remove from UI
                            LifeUp.GetComponent<Renderer>().sortingOrder = -1;
                            CurrentDown.transform.position = new Vector2(playerRB.transform.position.x, playerRB.transform.position.y - 1);
                        }

                        // Pick up new item
                        if (ItemsInRange[i].GetComponent<OdinAle>())
                        {
                            OdinAle = GameObject.Find("OA_UI");
                            OdinAle.transform.position = downItem.transform.position;
                            OdinAle.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<BatteryBread>())
                        {
                            BatteryBread = GameObject.Find("BB_UI");
                            BatteryBread.transform.position = downItem.transform.position;
                            BatteryBread.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<SwiftSauce>())
                        {
                            SwiftSauce = GameObject.Find("SS_UI");
                            SwiftSauce.transform.position = downItem.transform.position;
                            SwiftSauce.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        else if (ItemsInRange[i].GetComponent<LifeUp>())
                        {
                            LifeUp = GameObject.Find("SS_UI");
                            LifeUp.transform.position = downItem.transform.position;
                            LifeUp.GetComponent<Renderer>().sortingOrder = 1;
                            downItemTemp = ItemsInRange[i].gameObject;
                            CurrentDown = ItemsInRange[i].gameObject;
                            CurrentDown.transform.position = new Vector2(0, -1000);
                        }
                        break;
                    }
                }
            }
        }
    }

    public GameObject getUpItem()
    {
        return upItemTemp;
    }
    public GameObject getLeftItem()
    {
        return leftItemTemp;
    }
    public GameObject getRightItem()
    {
        return rightItemTemp;
    }
    public GameObject getDownItem()
    {
        return downItemTemp;
    }

    public bool isUpItem()
    {
        if (upItemTemp == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isLeftItem()
    {
        if (leftItemTemp == null)
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
        if (rightItemTemp == null)
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
        if (downItemTemp == null)
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

    public void SetUpUsed()
    {
        upItemUsed = true;
        isUp = true;
    }
    public void SetLeftUsed()
    {
        leftItemUsed = true;
        isLeft = true;
    }
    public void SetRightUsed()
    {
        rightItemUsed = true;
        isRight = true;
    }
    public void SetDownUsed()
    {
        downItemUsed = true;
        isDown = true;
    }

    

}
