using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int controllerNumber;
    private float moveSpeed;
    private float range;
    private float damage;
    private float health;
    private float attackSpeed;

    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }

    public float Health { get => health; set => health = value; }

    public float Damage { get => damage; set => damage = value; }

    public float Range { get => range; set => range = value; }

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
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
