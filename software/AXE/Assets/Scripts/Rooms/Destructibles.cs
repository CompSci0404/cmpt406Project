using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibles : MonoBehaviour
{

    private float health;
    public GameObject ParticleDamage;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame

    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        health -= damage;
        //Instantiate(ParticleDamage, transform.position, Quaternion.identity);
        
        if (health <= 0)
        {
            // could add a different drop system for different object
            // just add a new function like NormalDrops and add a enuerator myDropType 
            // then will have an if statement depending on myDropType
            // for now its just NormalDrops
            NormalDrops();

            //destroy object if animator has not been hooked up
            if (animator == null)
            {
                Destroy(this.gameObject);
            }

            else
            {
                animator.SetTrigger("hit");
                // could change destroy to animation to transition to destroyedObject state
                Invoke("destroyObject", 0.5f);
            }
        }
    }

    public void NormalDrops()
    {
        // Destructible drop chance of 1 coin 60%, 2 coins is 10%, 0 coins 30%
        // 1 - 60 == 1 coin, 61 - 70 == 2 coins, 71 - 100 == 0 coins
        int numCoins = Random.Range(1, 101);
        if (numCoins <= 60)
        {
            GameObject coin1 = Instantiate((GameObject)Resources.Load("Prefabs/Coin"), new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
        }
        else if (numCoins > 60 && numCoins < 70)
        {
            GameObject coin1 = Instantiate((GameObject)Resources.Load("Prefabs/Coin"), new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
            GameObject coin2 = Instantiate((GameObject)Resources.Load("Prefabs/Coin"), new Vector2(this.transform.position.x + .25f, this.transform.position.y + .25f), Quaternion.identity) as GameObject;
        }
    }

    public void destroyObject()
    {
        Destroy(this.gameObject);
    }
}
