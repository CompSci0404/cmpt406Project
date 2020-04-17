using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValkAnimationInput : MonoBehaviour, AnimationInput
{
    [SerializeField]
    private Animator valkAnimator;

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

    public void DeathAnimTrigger()
    {
        valkAnimator.SetTrigger("Death");
    }

    public void SwapAnimTrigger()
    {
        valkAnimator.SetTrigger("Swap");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponentInChildren<PlayerStats>().GetControllerNumber() == 2)
        {
            lookDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));

            if (gameObject.activeInHierarchy)
            {

                if (movement.x == 0f && movement.y == 0f)
                {
                    valkAnimator.SetBool("Moving", false);
                }
                else
                {
                    valkAnimator.SetBool("Moving", true);
                    moveAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                    if (moveAngle < -45.0f) moveAngle += 360.0f;
                    valkAnimator.SetFloat("MoveAngle", moveAngle);
                }
                lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                lookAngle -= 90.0f;
                if (lookAngle < -45.0f) lookAngle += 360.0f;
                valkAnimator.SetFloat("LookAngle", lookAngle);
            }
        }
        else
        {
            return;
        }
    }
}
