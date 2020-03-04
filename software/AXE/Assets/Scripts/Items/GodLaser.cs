using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodLaser : ItemClass
{
    private GameObject playerCont;
    private Rigidbody2D playerRB;
    private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        itemEffect = UseGodLaser;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = GetComponent<Rigidbody2D>();
    }


    public void UseGodLaser()
    {
        // search for current player stats
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            playerCont = GameObject.FindWithTag("Thor");
        }
        else
        {
            playerCont = GameObject.FindWithTag("Type2");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(playerRB.position, new Vector2(1f, 5f), LayerMask.NameToLayer("Enemy"));
        Debug.Log(hitEnemies.Length);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i].CompareTag("BaseEnemy"))
            {
                hitEnemies[i].GetComponent<AIClass>().Damage(stats.GetDamage()*4);
                Debug.Log("GodLaser Used");
            }

        }
        // move back player cont to 
        playerCont = GameObject.FindWithTag("Player");
    }
        //// attack range arch
    void OnDrawGizmosSelected()
     {
            Gizmos.DrawWireSphere(playerRB.position, stats.GetRange() / 3);
     }
    
}
