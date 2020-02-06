using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        float damage = parent.GetComponent<PlayerStats>().GetDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BaseEnemy")
        {
            // Weapon does damage
            Debug.Log("Base Enemy interaction");

        }
        else if (collision.gameObject.tag == "Type1Enemy" && parent.tag == "Type1")
        {
            // Weapon does damage
            Debug.Log("Type 1 interaction");
        }
        else if (collision.gameObject.tag == "Type2Enemy" && parent.tag == "Type2")
        {
            // Weapon does damage
            Debug.Log("Type 2 interaction");
        }
    }
}
