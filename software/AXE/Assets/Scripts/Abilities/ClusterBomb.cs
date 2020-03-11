using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A cluster of powerful micro explosives is released in a large radius around the character who switched out, damaging all enemies caught in the blast.
/// </summary>
public class ClusterBomb : ItemClass
{
    private MainControls swapCheck;
    GameObject player;
    ParticleSystem explosion;
    SpriteRenderer sprite;
    float power = 5f;
    float radius = 1.5f;
    float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = Detonate;
        swapCheck = FindObjectOfType<MainControls>();
        player = GameObject.FindGameObjectWithTag("Player");
        explosion = gameObject.GetComponent<ParticleSystem>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Detonate()
    {
        if (swapCheck.justSwapped)
        {
            sprite.enabled = false;
            explosion.transform.position = player.transform.position;
            explosion.Play();
            Vector2 bombPosition = player.transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(bombPosition, radius);

            foreach (Collider2D hit in colliders)
            {
                AIClass ai = hit.GetComponent<AIClass>();
                Rigidbody2D rBody = hit.GetComponent<Rigidbody2D>();
                if (ai != null)
                {
                    ai.Damage(damage);
                }
                if (rBody != null)
                {
                    Vector2 force = new Vector2(1, 1);
                    rBody.AddForceAtPosition(force, bombPosition);
                }
            }

        }
        else
        {
            return;
        }
    }
}
