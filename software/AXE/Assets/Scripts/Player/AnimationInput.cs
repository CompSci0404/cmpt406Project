using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface AnimationInput
{
    void SetMovement(Vector2 move);
    void SetLook(Vector2 look);
    void AttackAnimTrigger();
}