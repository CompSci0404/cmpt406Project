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

    float thorAttackSpeed = .5f;
    float thorAttackDamage = 2.5f;

    [SerializeField] private Transform weaponPoint;

    [SerializeField]
    private ThorAnimationInput thorAnimation;

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
        movement.y = Input.GetAxis("Vertical");
        if (movement.x > 0)
        {
            Vector2 weaponPosition = new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y);
            weaponPoint.transform.position = weaponPosition;
        }
        else if (movement.x < 0)
        {
            Vector2 weaponPosition = new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y);
            weaponPoint.transform.position = weaponPosition;
        }
        else if (movement.y > 0)
        {
            Vector2 weaponPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1f);
            weaponPoint.transform.position = weaponPosition;
        }
        else if (movement.y < 0)
        {
            Vector2 weaponPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f);
            weaponPoint.transform.position = weaponPosition;
        }

        // used canAttack bool so MeleeAttack updates correctly
        if (attackTime <= 0)
        {
            canAttack = true;
            attackTime = stats.GetAttackSpeed() + thorAttackSpeed;
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
            thorAnimation.AttackAnimTrigger();
            FindObjectOfType<AudioManager>().PlaySound("ThorSwing");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponPoint.position, stats.GetRange() / 3, enemyLayers);
            for( int i = 0; i < hitEnemies.Length; i++ )
            {
                if (hitEnemies[i].CompareTag("BaseEnemy") || hitEnemies[i].CompareTag("rngBlock"))
                {
                    hitEnemies[i].GetComponent<AIClass>().Damage(stats.GetDamage() + thorAttackDamage);
                }
            }
            canAttack = false;
        }  
    }
}
