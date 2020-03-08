using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainControls : MonoBehaviour
{
    private PlayerStats stats;
    public HUD HUD;

    [SerializeField]
    private ThorAnimationInput thorAnimation;
    [SerializeField]
    private ValkAnimationInput valkAnimation;

    [SerializeField] private GameObject reticle;

    public bool justSwapped;

    private string horizontalAxis;
    private string verticalAxis;
    private string aButton;
    private string bButton;
    private string xButton;
    private string yButton;
    private int controllerNumber;

    private string lbButton;

    private string rightTrigger;
    private float rightStickAngle;
    private Vector2 rightStickDirection;

    private List<GameObject> players;

    private string lastDPadPressed;

    public string swapAbility;

    // Start is called before the first frame update
    void Awake()
    {
        // set for testing
        //swapAbility = "ClusterBomb";

        lastDPadPressed = "up";
        HUD = FindObjectOfType<HUD>();
        players = new List<GameObject>();
        int count = transform.childCount;
        // Get movement script from this object
        for (int i = 0; i < count; i++)
        {
            players.Add(transform.GetChild(i).gameObject);
        }
        SwapPlayer();
        reticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // take right stick to move reticle around player
        rightStickDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical")).normalized;
        rightStickAngle = Mathf.Atan2(rightStickDirection.y, rightStickDirection.x) * Mathf.Rad2Deg - 180f;
        if (Input.GetAxis(rightTrigger) > 0 && gameObject.GetComponent<Abilities>().isAbility())
        {
            reticle.SetActive(true);
        }
        else if (Input.GetAxis(rightTrigger) <= 0 && gameObject.GetComponent<Abilities>().isAbility())
        { 
            reticle.SetActive(false);
        }
        // aim reticle
        reticleAim();

        // wait for an input and set opposite player controller active
        if (Input.GetButtonDown(yButton)) {
            if (justSwapped)
            {
                //cannot switch yet
            }
            else
            {
                justSwapped = true;

                if (controllerNumber == 1)
                {
                    HUD.ThorSwitch = true;
                    HUD.ChangeCharacterIcon();
                    thorAnimation.SwapAnimTrigger();
                    stats.SetLives(stats.GetLives() - 1);
                    Invoke("SwapPlayer", 1);
                    
                }
                // if player 2 range
                else if (controllerNumber == 2)
                {
                    HUD.ValkSwitch = true;
                    HUD.ChangeCharacterIcon();
                    valkAnimation.SwapAnimTrigger();
                    stats.SetLives(stats.GetLives() - 1);
                    Invoke("SwapPlayer", 1);
                    
                }
            }
        }

        else if (Input.GetButtonDown(bButton))
        {
            Attack();       
        }
        else if (Input.GetButtonDown(aButton))
        {
            UseAbility();
        }
        else if (Input.GetButtonDown(xButton))
        {
            PickUpItem();
            PickUpAbility();
        }

        // DPad presses
        else if (DPad.IsUp)
        {
            lastDPadPressed = "up";
            Debug.Log("last pressed up");
        }
        else if (DPad.IsDown)
        {
            lastDPadPressed = "down";
            Debug.Log("last pressed down");
        }
        else if (DPad.IsLeft)
        {
            lastDPadPressed = "left";
            Debug.Log("last pressed left");
        }
        else if (DPad.IsRight)
        {
            lastDPadPressed = "right";
            Debug.Log("last pressed right");
        }
        else if (Input.GetButtonDown(lbButton))
        {
            UseItem();
        }
        // player has a method that activates when it becomes active and sends its stats to this class
    }

    private void SwapPlayer()
    {
        if (null != stats) stats.gameObject.SetActive(false);
        GameObject nextPlayer = players[0];
        nextPlayer.SetActive(true);

        players.Remove(nextPlayer);
        players.Add(nextPlayer);

        if (swapAbility.Equals(""))
        {
            Debug.Log("No Ability");
        }
        else { this.GetComponent<Abilities>().GetSwapAbility().GetComponentInChildren<ItemClass>().ItemActivate(); }
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
            Debug.Log("Player 1 Melee Attacking");
            thorAnimation.AttackAnimTrigger();
            this.GetComponentInChildren<MeleeAttack>().MeleeAtt();
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            Debug.Log("Player 2 Range Attacking");
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
            }
            else if (lastDPadPressed == "left" && !this.GetComponent<Inventory>().isLeftItem())
            {
                this.GetComponent<Inventory>().getLeftItem().GetComponentInChildren<ItemClass>().ItemActivate();
            }
            else if (lastDPadPressed == "right" && !this.GetComponent<Inventory>().isRightItem())
            {
                this.GetComponent<Inventory>().getRightItem().GetComponentInChildren<ItemClass>().ItemActivate();
            }
            else if (lastDPadPressed == "down" && !this.GetComponent<Inventory>().isDownItem())
            {
                this.GetComponent<Inventory>().getDownItem().GetComponentInChildren<ItemClass>().ItemActivate();
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
            }
            else if (lastDPadPressed == "left" && !this.GetComponent<Inventory>().isLeftItem())
            {
                this.GetComponent<Inventory>().getLeftItem().GetComponentInChildren<ItemClass>().ItemActivate();
            }
            else if (lastDPadPressed == "right" && !this.GetComponent<Inventory>().isRightItem())
            {
                this.GetComponent<Inventory>().getRightItem().GetComponentInChildren<ItemClass>().ItemActivate();
            }
            else if (lastDPadPressed == "down" && !this.GetComponent<Inventory>().isDownItem())
            {
                this.GetComponent<Inventory>().getDownItem().GetComponentInChildren<ItemClass>().ItemActivate();
            }
        }
        // if player 2 use P2 A1
    }

    // Ability 2
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

    // Ability 1
    private void UseAbility()
    {
        if (controllerNumber == 1)
        {
            if (GetComponent<Abilities>().aAvailable)
            {
                Debug.Log("NO ITEM");
            }
            else { this.GetComponent<Abilities>().getaAbility().GetComponentInChildren<ItemClass>().ItemActivate(); }
        }
        else if (controllerNumber == 2)
        {
            if (GetComponent<Abilities>().aAvailable)
            {
                Debug.Log("NO ITEM");
            }
            else { this.GetComponent<Abilities>().getaAbility().GetComponentInChildren<ItemClass>().ItemActivate(); }
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
    }

    // get dpad last position
    public string getDPadLastPos()
    {
        return lastDPadPressed;
    }

    public int getControllerNumber()
    {
        return controllerNumber;
    }

    public string GetSwapAbility()
    {
        return swapAbility;
    }
    public void reticleAim()
    {
        reticle.transform.rotation = Quaternion.Euler(0, 0, rightStickAngle);
        //reticle.transform.position = new Vector2 (reticle.transform.position.x*rightStickDirection.x, reticle.transform.position.y*rightStickDirection.y);
    }
    public Vector2 getRSDirection()
    {
        return rightStickDirection;
    }

    public float getRSAngle()
    {
        return rightStickAngle;
    }
}
