using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorAnimationInput : MonoBehaviour, AnimationInput
{
    [SerializeField]
    private Animator thorAnimator;

    private float moveAngle;
    private float lookAngle;
    private Vector2 movement;
    private Vector2 lookDirection;

    public void SetMovement(Vector2 move)
    {
        movement = move;
    }

    public void SetLook(Vector2 look)
    {
        lookDirection = look;
    }

    public void AttackAnimTrigger()
    {
        thorAnimator.SetTrigger("Attack");
    }

    public void DeathAnimTrigger()
    {
        thorAnimator.SetTrigger("Death");
    }

    public void SwapAnimTrigger()
    {
        thorAnimator.SetTrigger("Swap");
    }

    // Update is called once per frame
    void Update()
    {
       lookDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));

        if (gameObject.activeInHierarchy)
        {

            if(movement.x == 0f && movement.y == 0f)
            {
                thorAnimator.SetBool("Moving", false);
            } else
            {
                thorAnimator.SetBool("Moving", true);
                moveAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                if (moveAngle < -45.0f) moveAngle += 360.0f;
                thorAnimator.SetFloat("MoveAngle", moveAngle);
            }
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            lookAngle -= 90.0f;
            if (lookAngle < -45.0f) lookAngle += 360.0f;
            thorAnimator.SetFloat("LookAngle", lookAngle);
        }
    }
}
