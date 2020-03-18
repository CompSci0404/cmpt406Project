using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private PlayerStats stats;
    public LayerMask enemyLayers;

    private float attackTime;
    Vector2 lookDirection;
    Vector2 movement;
    Rigidbody2D rBody;

    [SerializeField] private Transform weaponPoint;

    private bool canAttack;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        rBody = GetComponent<Rigidbody2D>();
        attackTime = 0f;
        weaponPoint.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        if (movement.x > 0)
        {
            Vector2 weaponPosition = new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y);
            weaponPoint.transform.position = weaponPosition;
        }
        else if (movement.x < 0)
        {
            Vector2 weaponPosition = new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y);
            weaponPoint.transform.position = weaponPosition;
        }

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
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponPoint.position, stats.GetRange() / 3, enemyLayers);
            for( int i = 0; i < hitEnemies.Length; i++ )
            {
                if (hitEnemies[i].CompareTag("BaseEnemy"))
                {
                    hitEnemies[i].GetComponent<AIClass>().Damage(stats.GetDamage());
                    Debug.Log("Player 1 Melee Attacking Enemy");
                }
            }
            canAttack = false;
        }  
    }
}
