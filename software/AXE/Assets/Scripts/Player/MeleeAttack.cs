using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    /// <summary>
    /// attackPoint point where the weapon is
    /// attackRange from stats of each player
    /// enemyLayer 
    /// </summary>
    private Transform attackPoint;
    private float attackRange;
    public LayerMask enemyLayers;

    // Update is called once per frame
    
    void Awake()
    {
        //attackPoint = this.GetComponentInChildren<Transform>();
        //attackRange = this.GetComponent<PlayerStats>().GetRange();
    }
    // Melee attack of character
    public void MlAttack()
    {
        Debug.Log("Player 1 Melee Attack");
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //foreach(Collider2D enemy in hitEnemies)
        //{
        //    Debug.Log("Melee Attack");
        //}
    }

    // attack range arch
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
}
