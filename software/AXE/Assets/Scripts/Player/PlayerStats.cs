using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int controllerNumber;
    private float moveSpeed;
    private float range;
    private float damage;
    private float maxHealth;
    private float currHealth;
    private float attackSpeed;
    private int lives;

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public void SetAttackSpeed(float value)
    {
        attackSpeed = value;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(float value)
    {
        maxHealth = value;
    }

    public float GetCurrHealth()
    {
        return currHealth;
    }

    public void SetCurrHealth(float value)
    {
        currHealth = value;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    public float GetRange()
    {
        return range;
    }

    public void SetRange(float value)
    {
        range = value;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int life)
    {
        lives = life;
    }

    void Awake()
    {
        // initialize stats
        moveSpeed = 10f;
        range = 1f;
        damage = 5f;
        maxHealth = 10f;
        currHealth = GetMaxHealth();
        attackSpeed = 1.25f;
        lives = 3;
    }

    public int GetControllerNumber()
    {
        return controllerNumber;
    }

    // Enemy damage will call this method
    public void DamagePlayer(float damage)
    {
        float health = GetCurrHealth();

        health -= damage;

        SetCurrHealth(health);

        if (GetCurrHealth() <= 0 && GetLives() <= 0)
        {
            Death();
        }
        else if (GetCurrHealth() <= 0 && GetLives() > 0)
        {
            Respawn();
        }
    }

    // Will have to set to other controller? 
    // Respawns the character with one less life
    private void Respawn()
    {
        // Death animation && give invincibility
        SetLives(GetLives() - 1);
        Debug.Log("Player lost a life");
        SetCurrHealth(GetMaxHealth());
    }

    // Full death of player
    private void Death()
    {
        Debug.Log("Wah I am dead :(");

        // this will destroy the SwapContoller Object (this can be final death) 
        Destroy(this.gameObject, 2.5f);
    }

}
