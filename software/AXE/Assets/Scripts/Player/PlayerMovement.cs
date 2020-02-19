using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rBody;
    Vector2 movement;

    float moveSpeed;

    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponent<PlayerStats>();
        rBody = gameObject.GetComponent<Rigidbody2D>();
        movement = new Vector2();
        moveSpeed = stats.GetMoveSpeed();
    }

    // Update is called once per frame and gets users inputs
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
    }

    // After the update frame gets the users input, fixed update will move the player.
    private void FixedUpdate()
    {

        if (movement.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        rBody.MovePosition(rBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
