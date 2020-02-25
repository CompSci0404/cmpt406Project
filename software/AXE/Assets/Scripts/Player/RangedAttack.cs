using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to be put on our ranged character that will enable them to shoot.
/// </summary>
public class RangedAttack: MonoBehaviour
{
    private Camera camera;
    private Rigidbody2D rBody;

    public GameObject arrowPrefab;
    private float timer = 0f;
    private PlayerStats stats;


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        rBody = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate direction of shot
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 target = mousePos - rBody.position;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90f;

        if (timer > 0)
        {
            timer = Mathf.Max(0, timer - Time.deltaTime);
        }
        else if (Input.GetButton("Fire1"))
        {
            ShootArrow(angle);
            timer = stats.GetAttackSpeed();
        }
    }

    // Called when the active player hits their attack button
    private void ShootArrow(float angle)
    {
        GameObject arrow = Instantiate(arrowPrefab, rBody.position, Quaternion.AngleAxis(angle, Vector3.forward));
        arrow.transform.Translate(Vector3.up * 0.5f);

        arrow.GetComponent<Arrow>().SetDamage(stats.GetDamage());

        Vector2 arrowForce = (Vector2)(arrow.transform.up * stats.GetAtkForce()) + rBody.velocity / 2;

        Rigidbody2D arrowRB = arrow.GetComponent<Rigidbody2D>();
        arrowRB.AddForce(arrowForce, ForceMode2D.Impulse);
    }
}
