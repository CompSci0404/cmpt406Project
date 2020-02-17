using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameObject parent;
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        damage = parent.GetComponent<PlayerStats>().GetDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BaseEnemy")
        {
            // Weapon does damage
            Debug.Log("Base Enemy interaction");
            collision.gameObject.GetComponent<AIClass>().Damage(damage);
        }
        else if (collision.gameObject.tag == "Type1Enemy" && parent.tag == "Type1")
        {
            // Weapon does damage
            Debug.Log("Type 1 interaction");


            collision.gameObject.GetComponent<AIClass>().Damage(damage);
        }
        else if (collision.gameObject.tag == "Type2Enemy" && parent.tag == "Type2")
        {
            // Weapon does damage
            Debug.Log("Type 2 interaction");
            collision.gameObject.GetComponent<AIClass>().Damage(damage);
        }
        else if (collision.gameObject.tag == "Type1Enemy" && parent.tag == "Type2" 
            || collision.gameObject.tag == "Type2Enemy" && parent.tag == "Type1")
        {
            Debug.Log("Wrong type! Switch to other player!");
        }
    }
}
