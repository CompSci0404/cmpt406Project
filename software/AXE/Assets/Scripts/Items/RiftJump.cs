using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftJump : ItemClass
{
    
    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;

    private Vector2 lookDirection;
    private float angle;

    void Start()
    {
        itemEffect = UseRiftJump;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
    }

    public void UseRiftJump()
    {
        angle = playerCont.GetComponent<MainControls>().getRSAngle();
        lookDirection = playerCont.GetComponent<MainControls>().getRSDirection();
        GameObject jump = Instantiate((GameObject)Resources.Load("RiftJumpLocation"), playerRB.transform.position, Quaternion.Euler(0, 0, angle)) as GameObject;

        Vector2 jumpForce = (Vector2)(jump.transform.up * 50f) + playerRB.velocity / 2;

        Rigidbody2D jumpRB = jump.GetComponent<Rigidbody2D>();
        jumpRB.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
