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
    private bool hasIndicator;
    private int playerItemUsed;
    private bool usable;

    [SerializeField] private int abilityCooldown;
    private int cooldown;
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
            if(cooldown == 0)
            {
                itemEffect();
                cooldown = abilityCooldown;
            }
            else
            {
                Invoke("itemEffect", abilityCooldown);
            }
            
        }
    }

    public void TempTimer()
    {
        cooldown = 0;
    }

    public void setHasIndicator(bool boolIndicator)
    {
        hasIndicator = boolIndicator;
    }

    public float getItemMultiplier()
    {
        return itemMultiplier;
    }
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

    public int GetAbilityCooldown()
    {
        return abilityCooldown;
    }
    public void setAbilityCooldown(int cooldown)
    {
        abilityCooldown = cooldown;
    }
}
