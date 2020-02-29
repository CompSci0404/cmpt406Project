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

    [SerializeField] private int ItemCooldown;

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
            Debug.Log("not yet implemented");
        }
        else if (myItemType == ItemType.playerAbility)
        {
            Debug.Log("abilityItem not yet implemented");
        }
    }

}
