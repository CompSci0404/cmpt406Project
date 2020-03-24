using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rBody;
    Vector2 movement;
    Vector2 lookDirection;
    float angle;

    float moveSpeed;

    private PlayerStats stats;
    private PlayerMovement pMovement;

    [SerializeField]
    private ThorAnimationInput thorAnimation;
    [SerializeField]
    private ValkAnimationInput valkAnimation;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponentInChildren<PlayerStats>();

        rBody = gameObject.GetComponent<Rigidbody2D>();
        movement = new Vector2();
        lookDirection = new Vector2();
        moveSpeed = stats.GetMoveSpeed();
    }

    // Update is called once per frame and gets users inputs
    void Update()
    {
        // update movement speed based on current player stat
        if (gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            stats = gameObject.transform.GetChild(0).GetComponent<PlayerStats>();
        }
        else if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            stats = gameObject.transform.GetChild(1).GetComponent<PlayerStats>();
        }

        moveSpeed = stats.GetMoveSpeed();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        thorAnimation.SetMovement(movement);
        valkAnimation.SetMovement(movement);

        // Contoller Inputs
        lookDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));
        Vector2 target = lookDirection - rBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        thorAnimation.SetLook(lookDirection);
        valkAnimation.SetLook(lookDirection);
    }

    // After the update frame gets the users input, fixed update will move the player.
    private void FixedUpdate()
    {
        rBody.MovePosition(rBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        rBody.SetRotation(angle);
    }
}
