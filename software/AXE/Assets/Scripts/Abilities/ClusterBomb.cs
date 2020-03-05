using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A cluster of powerful micro explosives is released in a large radius around the character who switched out, damaging all enemies caught in the blast.
/// </summary>
public class ClusterBomb : ItemClass
{
    private MainControls swapCheck;
    public GameObject bomb;
    float power = 5f;
    float radius = 1.5f;
    float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<ParticleSystem>().Stop();
        itemEffect = Detonate;
        swapCheck = FindObjectOfType<MainControls>();
    }

    void Detonate()
    {
        if(swapCheck.justSwapped)
        {
            Vector2 explosionPosition = bomb.transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, radius);

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
                    rBody.AddForceAtPosition(force, explosionPosition);
                }
            }
        }
        else
        {
            return;
        }
    }
}
