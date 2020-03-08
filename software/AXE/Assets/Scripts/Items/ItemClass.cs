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

    [SerializeField] private int ItemCooldown;
    // if item or ability has an area indicator to show the player
    
    [SerializeField] private GameObject spellIndicatior;

    // use any type of item with one function
    public delegate void ItemDelegate();
    public ItemDelegate itemEffect;


    
    public void ItemActivate()
    {
        if(myItemType == ItemType.consumable)
        {
            itemEffect();
            Destroy(this.gameObject);
        }
        else if (myItemType == ItemType.swapAbility)
        {
            itemEffect();
        }
        else if (myItemType == ItemType.playerAbility)
        {
            itemEffect();
        }
    }

    public void setHasIndicator(bool boolIndicator)
    {
        hasIndicator = boolIndicator;
    }

}
