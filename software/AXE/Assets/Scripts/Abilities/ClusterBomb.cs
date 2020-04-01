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
    SpriteRenderer sprite;
    CircleCollider2D collider;
    float power = 5f;
    float radius = 1.5f;
    float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = Detonate;
        swapCheck = FindObjectOfType<MainControls>();
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<CircleCollider2D>();
    }

    void Detonate()
    {
        if (swapCheck.justSwapped)
        {
            sprite.enabled = false;
            collider.enabled = false;
            PlayExplosion();
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
                if (hit.CompareTag("Destructibles"))
                {
                    hit.GetComponent<Destructibles>().Damage(damage);
                }
            }

        }
        else
        {
            return;
        }
    }

    private void PlayExplosion()
    {
        ParticleSystem explosion = gameObject.GetComponent<ParticleSystem>();
        if (null != explosion)
        {
            explosion.transform.position = player.transform.position;
            explosion.Play();
        }
        else
        {
            Debug.LogError("Unable to retrieve ParticleSystem from " + gameObject.name);
        }

    }
}
