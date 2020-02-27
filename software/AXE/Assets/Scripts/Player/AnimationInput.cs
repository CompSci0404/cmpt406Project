using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInput : MonoBehaviour
{
    Vector2 movement;
    Vector2 lookDirection;
    public Animator thorAnimator;
    public Animator valkAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        if (movement.x >= -1 && movement.x < -0.2f)
        {
            thorAnimator.SetTrigger("run_left");
            valkAnimator.SetTrigger("run_left");
        }
        else if (movement.x <= 1 && movement.x > 0.2f)
        {
            thorAnimator.SetTrigger("run_right");
            valkAnimator.SetTrigger("run_right");
        }

        if (movement.y >= -1 && movement.y < -0.2f)
        {
            thorAnimator.SetTrigger("run_front");
            valkAnimator.SetTrigger("run_front");
        }
        else if (movement.y <= 1 && movement.y > 0.2f)
        {
            thorAnimator.SetTrigger("run_back");
            valkAnimator.SetTrigger("run_back");
        }

        //if ((movement.x <= .2f && movement.x >= -.2f) && (movement.y <= .2f && movement.y >= -.2f))
        //{
        //    thorAnimator.SetTrigger("idle_front");
        //    valkAnimator.SetTrigger("idle_front");
        //}

        //Debug.Log(lookDirection.ToString());

        if(lookDirection.x == 0.0f && lookDirection.y == 0.0f)
        {
            //Debug.Log("No Right Stick Input");
            thorAnimator.SetTrigger("idle_front");
        }

        if (lookDirection.y >= -0.5f && lookDirection.y <= 0)
        {
            thorAnimator.SetTrigger("idle_right");
            valkAnimator.SetTrigger("idle_right");
        }
        else if (lookDirection.y > 0 && lookDirection.y <= 0.5f)
        {
            thorAnimator.SetTrigger("idle_left");
            valkAnimator.SetTrigger("idle_left");
        }

        if (lookDirection.x >= -0.5f && lookDirection.x <= 0)
        {
            thorAnimator.SetTrigger("idle_front");
            valkAnimator.SetTrigger("idle_front");
        }
        else if (lookDirection.x > 0 && lookDirection.x <= 0.5f)
        {
            thorAnimator.SetTrigger("idle_back");
            valkAnimator.SetTrigger("idle_back");
        }
    }
}
