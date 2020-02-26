using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private PlayerStats stats;
    public LayerMask enemyLayers;
    private float attackTime;
    [SerializeField] private Transform weaponPoint;

    private bool canAttack;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        attackTime = 0f;
    }
    // Update is called once per frame

    void Update()
    {
        // used canAttack bool so MeleeAttack updates correctly
        if (attackTime <= 0)
        {
            canAttack = true;
            attackTime = stats.GetAttackSpeed();
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
        
    }
    // Melee attack of character
    // used in MainControls
    public void MeleeAtt()
    {
        if (canAttack)
        {
            
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponPoint.position, stats.GetRange(), enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<AIClass>().Damage(stats.GetDamage());
                Debug.Log("Player 1 Melee Attack");
            }
            canAttack = false;
        }
        
    }

    // attack range arch
    private void OnDrawGizmosSelected()
    {
        if (weaponPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(weaponPoint.position, stats.GetRange());
    }
    
}
