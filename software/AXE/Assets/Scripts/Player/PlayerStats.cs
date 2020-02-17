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

    void Awake()
    {
        // initialize stats
        moveSpeed = 30f;
        range = 1f;
        damage = 5f;
        health = 10f;
        attackSpeed = 1.25f;
    }

    public int GetControllerNumber()
    {
        return controllerNumber;
    }

}
