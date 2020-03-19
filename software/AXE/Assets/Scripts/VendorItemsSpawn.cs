using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorItemsSpawn : MonoBehaviour
{
    public enum SpawnType
    {
        consumable,
        swapAbility,
        playerAbility,
        all
    }

    [SerializeField] GameObject[] consumables;
    [SerializeField] GameObject[] swapAbilities;
    [SerializeField] GameObject[] playerAbilities;

    [SerializeField] private SpawnType mySpawnType;
    
    // Start is called before the first frame update
    void Start()
    {

        int index;
        GameObject itemForSale;
        if (mySpawnType == SpawnType.consumable)
        {
            Vector2 spawnPos = new Vector2(this.transform.position.x, this.transform.position.y + .2f);
            index = Random.Range(0, consumables.Length);
            itemForSale = Instantiate(consumables[index], spawnPos, Quaternion.identity);
            itemForSale.GetComponent<ItemClass>().SetNeedCoin(true);
        }
        else if (mySpawnType == SpawnType.swapAbility)
        {
            Vector2 spawnPos = new Vector2(this.transform.position.x, this.transform.position.y + .2f);
            index = Random.Range(0, swapAbilities.Length);
            itemForSale = Instantiate(swapAbilities[index], spawnPos, Quaternion.identity);
            itemForSale.GetComponent<ItemClass>().SetNeedCoin(true);
        }
        else if (mySpawnType == SpawnType.playerAbility)
        {
            Vector2 spawnPos = new Vector2(this.transform.position.x, this.transform.position.y + .2f);
            index = Random.Range(0, playerAbilities.Length);
            itemForSale = Instantiate(playerAbilities[index], spawnPos, Quaternion.identity);
            itemForSale.GetComponent<ItemClass>().SetNeedCoin(true);
        }
        else
        {
            List<GameObject[]> all = new List<GameObject[]>();
            all.Add(consumables);
            all.Add(swapAbilities);
            all.Add(playerAbilities);
            GameObject[] picked = all[Random.Range(0, all.Count)];
            Vector2 spawnPos = new Vector2(this.transform.position.x, this.transform.position.y + .2f);
            index = Random.Range(0, picked.Length);
            itemForSale = Instantiate(picked[index], spawnPos, Quaternion.identity);
            itemForSale.GetComponent<ItemClass>().SetNeedCoin(true);
        }
        this.GetComponentInChildren<Text>().text = itemForSale.GetComponent<ItemClass>().GetPrice() + " Coins";

    }
}
