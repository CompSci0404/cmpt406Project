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
    public void DropCoin(Transform t)
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        GameObject coin = Instantiate(coinObject, t.position, rotation);
    }

    // Called by an enemy to get a chance to drop an item
    public void DropFromPools(Transform t)
    {
        int randInt = Random.Range(0, 101);

        //if (randInt <= dropChance)
        //    DropSwap(t);
        //else if (randInt > dropChance && randInt <= dropChance + dropChance)
        //    DropItem(t);
        //else if (randInt > dropChance + dropChance && randInt <= dropChance + dropChance + dropChance)
        //    DropConsumable(t);
        if (randInt <= dropChance * 5)
        {
            int numCoins = Random.Range(1, 5);
            for (int i = 0; i < numCoins; i++)
            {
                int spawnPlace = Random.Range(-1, 2);
                if (i==0)
                {
                    DropCoin(t);
                }
                else if (i == 1)
                {
                    t.position = new Vector2(t.position.x - (numCoins * spawnPlace) / 5f, t.position.y + (numCoins * spawnPlace) / 5f);
                }
                else if (i == 2)
                {
                    t.position = new Vector2(t.position.x - (numCoins * spawnPlace) / 5f, t.position.y - (numCoins * spawnPlace) / 5f);
                }
                else if (i == 3)
                {
                    t.position = new Vector2(t.position.x + (numCoins * spawnPlace) / 5f, t.position.y - (numCoins * spawnPlace) / 5f);
                }
                else
                {
                    t.position = new Vector2(t.position.x + (numCoins * spawnPlace) / 5f, t.position.y + (numCoins * spawnPlace) / 5f);
                    DropCoin(t);
                }
            }
        }
        else
            return;
    }
}
