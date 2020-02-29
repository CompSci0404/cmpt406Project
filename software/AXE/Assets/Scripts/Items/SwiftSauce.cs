using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftSauce : ItemClass
{

    
    void Start()
    {
        itemEffect = increaseSpeed;
    }
    
    public void increaseSpeed()
    {
        float attackSpeed = this.GetComponentInParent<PlayerStats>().GetAttackSpeed();
        float moveSpeed = this.GetComponentInParent<PlayerStats>().GetMoveSpeed();
        this.GetComponentInParent<PlayerStats>().SetAttackSpeed(attackSpeed * 1.5f);
        this.GetComponentInParent<PlayerStats>().SetMoveSpeed(moveSpeed * 1.5f);
    }
}
