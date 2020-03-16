using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that will be called on an enemies death to possibly drop an item from the item pools. 
/// </summary>
public class DropSystem : MonoBehaviour
{
    [SerializeField]
    public GameObject[] swapAbilities;
    [SerializeField]
    public GameObject[] itemAbilities;
    [SerializeField]
    public GameObject[] consumableItem;
    [SerializeField]
    public GameObject coinObject;
    
    // Each set has a 10% chance to drop
    public float dropChance = 10.0f;

    // Drop item from SwapAbility Pool 
    public void DropSwap(Transform t)
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        int swapIndex = Random.Range(0, swapAbilities.Length);
        GameObject swapAbility = Instantiate(swapAbilities[swapIndex], t.position, rotation);
    }

    // Drop item from ItemAbility Pool 
    public void DropItem(Transform t)
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        int itemIndex = Random.Range(0, itemAbilities.Length);
        GameObject itemAbility = Instantiate(itemAbilities[itemIndex], t.position, rotation);
    }

    // Drop item from ConsumableItem Pool 
    public void DropConsumable(Transform t)
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        int consumableIndex = Random.Range(0, consumableItem.Length);
        GameObject consumable = Instantiate(consumableItem[consumableIndex], t.position, rotation);
    }

    // Drop a coin
    public void DropCoins(Transform t)
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        int numCoins = Random.Range(0, 5);
        for (int i = 0; i < numCoins; i++)
        {
            GameObject coin = Instantiate(coinObject, t.position, rotation);
            coin.transform.position = new Vector2(t.position.x + (numCoins / 5), t.position.y + (numCoins / 5));
        }
    }

    // Called by an enemy to get a chance to drop an item
    public void DropFromPools(Transform t)
    {
        int randInt = Random.Range(0, 101);
        print(randInt);

        //if (randInt <= dropChance)
        //    DropSwap(t);
        //else if (randInt > dropChance && randInt <= dropChance + dropChance)
        //    DropItem(t);
        //else if (randInt > dropChance + dropChance && randInt <= dropChance + dropChance + dropChance)
        //    DropConsumable(t);
        if (randInt <= dropChance * 5)
        {
            DropCoins(t);
        }
        else
            return;
    }
}
