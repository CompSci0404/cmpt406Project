﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInput : MonoBehaviour
{
    Vector2 movement;
    Vector2 lookDirection;
    public Animator thorAnimator;

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

        if (gameObject.activeInHierarchy) {
            thorAnimator.SetFloat("MovementX", movement.x);
            thorAnimator.SetFloat("MovementY", movement.y);
            thorAnimator.SetFloat("LookX", lookDirection.x);
            thorAnimator.SetFloat("LookY", lookDirection.y);
        }
    }
}
