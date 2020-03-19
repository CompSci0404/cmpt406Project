using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : MonoBehaviour
{
    // consumable = one time use
    // swapAbility = used when swap used
    // playerAbility = unlimited use but cooldown base
    public enum ItemType
    {
        consumable,
        swapAbility,
        playerAbility
    }
    public string itemName;
    public string itemDescription;
    public ItemType myItemType;
    [SerializeField] int price;
    private bool needCoin;


    private bool hasIndicator;
    private int playerItemUsed;

    // for abilities. handles when abilities can be used
    private bool usable;
    private bool abilityJustUsed;

    // for Damage Over Time abilities
    private bool hasDot;
    private bool doDot;

    [SerializeField] private int abilityCooldown;
    private int curAbilityCooldown;
    [SerializeField] private float itemDuration;
    [SerializeField] private float itemMultiplier;
    // if item or ability has an area indicator to show the player

    // use any type of item with one function
    public delegate void ItemDelegate();
    public ItemDelegate itemEffect;
    
    public void ItemActivate()
    {
        if(myItemType == ItemType.consumable && usable)
        {
            itemEffect();
            usable = false;
            if (itemName == "SwiftSauce")
            {
                Invoke("ResetSpeed", itemDuration);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
        else if (myItemType == ItemType.swapAbility)
        {
            itemEffect();
        }
        else if (myItemType == ItemType.playerAbility)
        {
            
            if(curAbilityCooldown == 0)
            {
                curAbilityCooldown = abilityCooldown;
                itemEffect();
                abilityJustUsed = true;
                
            }
            if (abilityJustUsed)
            {
                // will be relocated at top of this else if statement and check if cooldown is 0 then change abilityJustUsed to false
                // just need room to call SetCurAbilityCooldown(abilityCooldown - 1) once a player finnish a room or once it calls roomClear()
                Invoke("TempTimer", abilityCooldown);
            }
        }
    }

    public void TempTimer()
    {
        curAbilityCooldown = 0;
        abilityJustUsed = false;
    }

    public void SetHasIndicator(bool boolIndicator)
    {
        hasIndicator = boolIndicator;
    }

    public float GetItemMultiplier()
    {
        return itemMultiplier;
    }

    // swift sauce reset 
    void ResetSpeed()
    {
        
        GameObject player = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject;
        
        if (playerItemUsed == 1)
        {
            Debug.Log("RESETTING 1");
            float attackSpeed = player.GetComponent<PlayerStats>().GetAttackSpeed();
            float moveSpeed = player.GetComponent<PlayerStats>().GetMoveSpeed();
            player.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed / itemMultiplier);
            player.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed / itemMultiplier);
        }
        
        else if (playerItemUsed == 2)
        {
            Debug.Log("RESETTING 2");
            player = GameObject.FindWithTag("Player").transform.GetChild(1).gameObject;
            float attackSpeed2 = player.GetComponent<PlayerStats>().GetAttackSpeed();
            float moveSpeed2 = player.GetComponent<PlayerStats>().GetMoveSpeed();
            player.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed2 / itemMultiplier);
            player.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed2 / itemMultiplier);
        }
        usable = true;
        Destroy(this.gameObject);

    }
    //

    // item cooldowns
    public void SetPlayerItemUsed(int player)
    {
        playerItemUsed = player;
    }
    public void SetUsable(bool boolUsable)
    {
        usable = boolUsable;
    }
    public bool GetUsable()
    {
        return usable;
    }
    //

    // ability cooldowns
    public int GetCurAbilityCooldown()
    {
        return curAbilityCooldown;
    }
    public void SetAbilityCooldown(int cooldown)
    {
        curAbilityCooldown = cooldown;
    }
    public bool GetAbilityJustUsed()
    {
        return abilityJustUsed;
    }
    //

    // Ability Damage Over Time

    public void SetHasDot(bool boolDot)
    {
        hasDot = boolDot;
    }
    public bool GetHasDot()
    {
        return hasDot;
    }
    public void SetDoDot(bool boolDot)
    {
        doDot = boolDot;
    }
    public bool GetDoDot()
    {
        return doDot;
    }
    //

    public void SetNeedCoin(bool coins)
    {
        needCoin = coins;
    }

    public bool GetNeedCoin()
    {
        return needCoin;
    }

    public int GetPrice()
    {
        return price;
    }
    public void BuyItem()
    {
        GameObject playerCont =  GameObject.FindWithTag("Player");
        PlayerStats stats;
        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }

        if (price <= stats.GetCoins())
        {
            stats.UseCoins(price);
            needCoin = false;
        }

    }
}
