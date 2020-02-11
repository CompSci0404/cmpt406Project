using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIClass : MonoBehaviour
{
    public float speed;
    public float fov;
    public float health;
    public float atkDamage;

    protected DecisionTree rootOfTree;

    // later we need to add damage for AI, HP

    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0) { Die(); }
    }

    public void Attack()
    {

    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
