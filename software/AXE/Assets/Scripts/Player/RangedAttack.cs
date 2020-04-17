using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to be put on our ranged character that will enable them to shoot.
/// </summary>
public class RangedAttack: MonoBehaviour
{
    GameObject parent;
    private Camera camera;
    private Rigidbody2D rBody;
    Vector2 lookDirection;

    public GameObject arrowPrefab;
    private float timer = 0f;
    private PlayerStats stats;

    private string rightTrigger;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        camera = FindObjectOfType<Camera>();
        rBody = parent.GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        rightTrigger = "RightTrigger";
    }

    // Update is called once per frame
    void Update()
    {
        // Contoller Inputs
        lookDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));
        Vector2 target = lookDirection - rBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 180f;

        if (timer > 0)
        {
            timer = Mathf.Max(0, timer - Time.deltaTime);
        }
        else if (Input.GetButtonDown("J2B") || Input.GetAxis(rightTrigger) > 0 || Input.GetMouseButton(0))
        {
            if (parent.GetComponent<MainControls>().canAttack)
            {
                // changed argument of ShootArrow from angle to current argument.
                ShootArrow(parent.GetComponent<MainControls>().GetRSAngle());
                timer = stats.GetAttackSpeed();
            }
        }
    }

    // Called when the active player hits their attack button
    private void ShootArrow(float angle)
    {
        GameObject arrow = Instantiate(arrowPrefab, rBody.position, Quaternion.AngleAxis(angle, Vector3.forward));
        arrow.transform.Translate(Vector3.up * 0.5f);

        FindObjectOfType<AudioManager>().PlaySound("ValkShot");

        arrow.GetComponent<Arrow>().SetDamage(stats.GetDamage());

        Vector2 arrowForce = (Vector2)(arrow.transform.up * stats.GetAtkForce()) + rBody.velocity / 2;

        Rigidbody2D arrowRB = arrow.GetComponent<Rigidbody2D>();
        arrowRB.AddForce(arrowForce, ForceMode2D.Impulse);
    }
}
