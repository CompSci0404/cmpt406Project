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

    private bool justRefreshed;
    private bool refreshable;
    // Start is called before the first frame update
    void Start()
    {
        justRefreshed = false;
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

        itemForSale.transform.parent = this.transform;
        this.GetComponentInChildren<Text>().text = itemForSale.GetComponent<ItemClass>().GetPrice() + " Coins";

    }

    // create a new item if item is gone
    public void Refresh()
    {
        justRefreshed = true;

        int index;
        GameObject itemForSale;
        if (this.transform.childCount > 1)
        {
            Destroy(this.GetComponentInChildren<ItemClass>().gameObject);
        }
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
        itemForSale.transform.parent = this.transform;
        this.GetComponentInChildren<Text>().text = itemForSale.GetComponent<ItemClass>().GetPrice() + " Coins";

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Ability") || collision.CompareTag("SwapAbility"))
        {
            Debug.Log("There is an item here");
            if (justRefreshed)
            {
                Destroy(collision.gameObject);
                justRefreshed = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Ability") || collision.CompareTag("SwapAbility"))
        {
            Debug.Log("There is no item here");
        }
    }
}
