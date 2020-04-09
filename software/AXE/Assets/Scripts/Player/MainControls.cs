using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainControls : MonoBehaviour
{
    public enum ControlType
    {
        xbox,
        mandk
    }
    private CoinStats coins;
    private PlayerStats stats;
    public HUD HUD;
    private Inventory inventory;

    [SerializeField]
    private ThorAnimationInput thorAnimation;
    [SerializeField]
    private ValkAnimationInput valkAnimation;

    public bool justSwapped;
    public bool canAttack;
    TimeSlowSwap swapSlow;
    
    private string horizontalAxis;
    private string verticalAxis;
    private string aButton;
    private string bButton;
    private string xButton;
    private string yButton;
    private int controllerNumber;
    private string lbButton;
    private string rightTrigger;
    private string leftTrigger;

    private GameObject reticle;
    private float rightStickAngle;
    private Vector2 rightStickDirection;

    private List<GameObject> players;

    private string lastDPadPressed;

    public string swapAbility;

    public GameObject swapMessage;

    private ScriptableControls myControls;
    // Start is called before the first frame update
    void Awake()
    {
        myControls = (ScriptableControls)Resources.Load("MyControls");
        swapSlow = this.GetComponent<TimeSlowSwap>();

        // Set Up on DPad
        lastDPadPressed = "up";

        // Get Components
        swapSlow = this.GetComponent<TimeSlowSwap>();
        HUD = FindObjectOfType<HUD>();
        inventory = FindObjectOfType<Inventory>();
        coins = FindObjectOfType<CoinStats>();
        players = new List<GameObject>();
        canAttack = true;

        int count = transform.childCount;
        // Get movement script from this object
        for (int i = 0; i < count; i++)
        {
            players.Add(transform.GetChild(i).gameObject);
        }
        SwapPlayer();
        }

    // Update is called once per frame
    void Update()
    {
        if (myControls.PC)
        {
            // update vector and angle for the right stick
            rightStickDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rightStickAngle = Mathf.Atan2(rightStickDirection.y, rightStickDirection.x) * Mathf.Rad2Deg - 90f;
        }
        else
        {
            // update vector and angle for the right stick
            rightStickDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical")).normalized;
            rightStickAngle = Mathf.Atan2(rightStickDirection.y, rightStickDirection.x) * Mathf.Rad2Deg - 180f;
        }
        
        // mouse control

        if (reticle == null)
        {
            reticle = Instantiate((GameObject)Resources.Load("Reticle"), this.gameObject.transform.position,
                Quaternion.Euler(0, 0, rightStickAngle)) as GameObject;
            reticle.SetActive(true);
        }
        // update position of reticle
        reticle.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);

        // take right stick to move reticle around player
        if (Input.GetAxis(rightTrigger) > 0 && gameObject.GetComponent<Abilities>().IsAbility() && !PauseMenu.GameIsPaused)
        {
            // create player reticle
            reticle.SetActive(true);
        }
        else if (Input.GetAxis(rightTrigger) <= 0 && gameObject.GetComponent<Abilities>().IsAbility())
        {
            reticle.SetActive(false);
        }

        // aim reticle
        Debug.Log(rightStickAngle);
        if (rightStickAngle < -15 && rightStickAngle > -60)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x + .5f, reticle.transform.position.y + .5f);
        }
        else if (rightStickAngle < -60 && rightStickAngle > -105)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x + .5f, reticle.transform.position.y);
        }
        else if (rightStickAngle < -105 && rightStickAngle > -150)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x + .5f, reticle.transform.position.y - .5f);
        }
        else if (rightStickAngle < -150 && rightStickAngle > -195)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x, reticle.transform.position.y - .5f);
        }
        else if (rightStickAngle < -195 && rightStickAngle > -240)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x - .5f, reticle.transform.position.y - .5f);
        }
        else if (rightStickAngle < -240 && rightStickAngle > -285)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x - .5f, reticle.transform.position.y);
        }
        else if (rightStickAngle < -285 && rightStickAngle > -330)
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x - .5f, reticle.transform.position.y + .5f);
        }
        else if (rightStickAngle < -330 && rightStickAngle > -360 || rightStickAngle < 0  && rightStickAngle > -15 )
        {
            reticle.transform.position = new Vector2(reticle.transform.position.x, reticle.transform.position.y + .5f);
        }

        //move reticle
        reticle.transform.rotation = Quaternion.Euler(0, 0, rightStickAngle);

        // Use the right trigger to attack 
        if ((Input.GetAxis(rightTrigger) > 0 || Input.GetMouseButton(0)) && !PauseMenu.GameIsPaused)
        {
            if (canAttack)
            {
                Attack();
            }
        }

        // wait for an input and set opposite player controller active
        if ((Input.GetButtonDown(yButton) || Input.GetMouseButtonDown(1)) && !PauseMenu.GameIsPaused)
        {
            if (justSwapped)
            {
                //cannot switch yet
            }
            else
            {
                justSwapped = true;
                swapSlow.SlowForSwap();
                canAttack = false;
                if (controllerNumber == 1)
                {
                    HUD.ThorSwitch = true;
                    HUD.ChangeCharacterIcon();
                    thorAnimation.SwapAnimTrigger();
                    if (swapAbility.Equals(""))
                    {
                    }
                    else
                    {
                        this.GetComponent<Abilities>().GetSwapAbility().GetComponentInChildren<ItemClass>().ItemActivate();
                    }
                    stats.SetLives(stats.GetLives() - 1);
                    this.GetComponent<PlayerMovement>().enabled = false;
                    Invoke("SwapPlayer", 1.5f);
                }
                // if player 2 range
                else if (controllerNumber == 2)
                {
                    HUD.ValkSwitch = true;
                    HUD.ChangeCharacterIcon();
                    valkAnimation.SwapAnimTrigger();
                    if (swapAbility.Equals(""))
                    {
                        Debug.Log("No Ability");
                    }
                    else
                    {
                        this.GetComponent<Abilities>().GetSwapAbility().GetComponentInChildren<ItemClass>().ItemActivate();
                    }
                    stats.SetLives(stats.GetLives() - 1);
                    this.GetComponent<PlayerMovement>().enabled = false;
                    Invoke("SwapPlayer", 1.5f);
                }
            }
        }

        else if (Input.GetButtonDown(bButton) || Input.GetMouseButtonDown(0))
        {
            if (canAttack && !PauseMenu.GameIsPaused)
            {
                Attack();
            }
        }
        else if (Input.GetButtonDown(aButton) || Input.GetAxis(leftTrigger) > 0 || Input.GetKey("q"))
        {
            if (!PauseMenu.GameIsPaused)
                UseAbility();
        }
        else if ((Input.GetButtonDown(xButton) || Input.GetKey("e")) && !PauseMenu.GameIsPaused)
        {
            if (GameObject.Find("Vendor").GetComponent<Vendor>().GetPlayerInRangeVendor())
            {
                // interact with vendor
                InteractVendor();
            }
            else
            {
                PickUpItem();
                PickUpAbility();
            }
        }

        // DPad presses
        else if (DPad.IsUp || Input.GetKey("1"))
        {
            lastDPadPressed = "up";
            gameObject.GetComponent<Inventory>().HighlightDPad(inventory.upItem);
        }
        else if (DPad.IsDown || Input.GetKey("2"))
        {
            lastDPadPressed = "down";
            gameObject.GetComponent<Inventory>().HighlightDPad(inventory.downItem);
        }
        else if (DPad.IsLeft || Input.GetKey("3"))
        {
            lastDPadPressed = "left";
            gameObject.GetComponent<Inventory>().HighlightDPad(inventory.leftItem);
        }
        else if (DPad.IsRight || Input.GetKey("4"))
        {
            lastDPadPressed = "right";
            gameObject.GetComponent<Inventory>().HighlightDPad(inventory.rightItem);
        }
        else if (Input.GetButtonDown(lbButton) || Input.GetKey("f"))
        {
            UseItem();
        }

        if (coins.thorCoins > 3 || coins.valkCoins > 3)
        {
            // create a portal at their location
        }
    }

    public void SwapPlayer()
    {
        if (null != stats)
        {
            stats.gameObject.SetActive(false);
        }
        GameObject nextPlayer = players[0];
        nextPlayer.SetActive(true);

        players.Remove(nextPlayer);
        players.Add(nextPlayer);

        this.GetComponent<PlayerMovement>().enabled = true;

        canAttack = true;
        Invoke("ResetSwap", 1);
    }

    private void ResetSwap()
    {
        justSwapped = false;
    }

    // Normal Attack
    private void Attack()
    {
        // if player 1 melee
        if (controllerNumber == 1)
        {
            this.GetComponentInChildren<MeleeAttack>().MeleeAtt();
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            // All code for player two shooting is in the ranged attack script
        }
    }

    // Ability 1
    private void UseItem()
    {
        // if player 1 use P1 A1
        if (controllerNumber == 1)
        {
            Debug.Log("Use Item thats in <" + lastDPadPressed + " DPad>");
            if (lastDPadPressed == "up" && !this.GetComponent<Inventory>().isUpItem())
            {
                this.GetComponent<Inventory>().getUpItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetUpUsed();
            }
            else if (lastDPadPressed == "left" && !this.GetComponent<Inventory>().isLeftItem())
            {
                this.GetComponent<Inventory>().getLeftItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetLeftUsed();
            }
            else if (lastDPadPressed == "right" && !this.GetComponent<Inventory>().isRightItem())
            {
                this.GetComponent<Inventory>().getRightItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetRightUsed();
            }
            else if (lastDPadPressed == "down" && !this.GetComponent<Inventory>().isDownItem())
            {
                this.GetComponent<Inventory>().getDownItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetDownUsed();
            }
            else
            {
                Debug.Log("Player has no item to use");
            }
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            Debug.Log("Use Item thats in <" + lastDPadPressed + " DPad>");

            if (lastDPadPressed == "up" && !this.GetComponent<Inventory>().isUpItem())
            {
                this.GetComponent<Inventory>().getUpItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetUpUsed();
            }
            else if (lastDPadPressed == "left" && !this.GetComponent<Inventory>().isLeftItem())
            {
                this.GetComponent<Inventory>().getLeftItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetLeftUsed();
            }
            else if (lastDPadPressed == "right" && !this.GetComponent<Inventory>().isRightItem())
            {
                this.GetComponent<Inventory>().getRightItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetRightUsed();
            }
            else if (lastDPadPressed == "down" && !this.GetComponent<Inventory>().isDownItem())
            {
                this.GetComponent<Inventory>().getDownItem().GetComponentInChildren<ItemClass>().ItemActivate();
                this.GetComponent<Inventory>().SetDownUsed();
            }
        }
        // if player 2 use P2 A1
    }

    private void PickUpItem()
    {
        // if player 1 use P1 A2
        if (controllerNumber == 1)
        {
            Debug.Log("Item Picked up goes to <" + lastDPadPressed + " DPad>");
            this.GetComponent<Inventory>().PickUpItem();

        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            Debug.Log("Item Picked up goes to <" + lastDPadPressed + " DPad>");
            this.GetComponent<Inventory>().PickUpItem();
        }
        // if player 2 use P2 A2
    }

    private void InteractVendor()
    {
        // if player 1 use P1 A2
        if (controllerNumber == 1)
        {
            GameObject.Find("Vendor").GetComponent<Vendor>().VendorInteract();
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            GameObject.Find("Vendor").GetComponent<Vendor>().VendorInteract();
        }
        // if player 2 use P2 A2
    }

    private void UseAbility()
    {
        if (controllerNumber == 1)
        {
            if (GetComponent<Abilities>().aAvailable)
            {
                Debug.Log("NO ABILITY");
            }
            else if (!this.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().GetAbilityJustUsed())
            {
                this.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().ItemActivate();
            }
            else
            {
                Debug.Log("ABILITY ON COOLDOWN");
            }
        }
        else if (controllerNumber == 2)
        {
            if (GetComponent<Abilities>().aAvailable)
            {
                Debug.Log("NO ABILITY");
            }
            else if (!this.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().GetAbilityJustUsed())
            {
                this.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().ItemActivate();
            }
            else
            {
                Debug.Log("ABILITY ON COOLDOWN");
            }
        }
    }

    // Ability 2
    private void PickUpAbility()
    {
        // if player 1 use P1 A2
        if (controllerNumber == 1)
        {
            this.GetComponent<Abilities>().PickUpAbility();
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            this.GetComponent<Abilities>().PickUpAbility();
        }
    }

    public void UpdateStats(PlayerStats stats)
    {
        // update the movement script with variables from player
        this.stats = stats;
        SetPlayerNumber(stats.GetControllerNumber());
    }

    private void SetPlayerNumber(int number)
    {
        controllerNumber = number;
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        verticalAxis = "J" + controllerNumber + "Vertical";
        aButton = "J" + controllerNumber + "A";
        bButton = "J" + controllerNumber + "B";
        xButton = "J" + controllerNumber + "X";
        yButton = "J" + controllerNumber + "Y";
        lbButton = "LeftBumper";
        rightTrigger = "RightTrigger";
        leftTrigger = "LeftTrigger";
    }

    // get dpad last position
    public string GetDPadLastPos()
    {
        return lastDPadPressed;
    }

    public int GetControllerNumber()
    {
        return controllerNumber;
    }

    public string GetSwapAbility()
    {
        return swapAbility;
    }
    public Vector2 GetRSDirection()
    {
        return rightStickDirection;
    }

    public float GetRSAngle()
    {
        return rightStickAngle;
    }
}
