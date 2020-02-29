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

    private Inventory inventory;
    
    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void UseItem()
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
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("item coll");
        if (collision.gameObject.tag == "Player" && (Input.GetButtonDown("J1X") || Input.GetButtonDown("J2X")))
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
