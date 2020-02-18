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
    private float health;
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

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float value)
    {
        health = value;
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
        health = 10f;
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
        float health = GetHealth();

        health -= damage;

        SetHealth(health);

        if (GetHealth() <= 0 && GetLives() <= 0)
        {
            Death();
        }
        else if (GetHealth() <= 0 && GetLives() > 0)
        {
            Respawn();
        }
    }

    // Will have to set to other controller? 
    // Respawns the character with one less life
    private void Respawn()
    {
        SetLives(GetLives() - 1);
        Debug.Log("Player lost a life");
    }

    // Full death of player
    private void Death()
    {
        Debug.Log("Wah I am dead :(");

        // this will destroy the SwapContoller Object (this can be final death) 
        Destroy(this.gameObject, 2.5f);
    }

}
