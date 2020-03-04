using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdinAle: MonoBehaviour
{
    private static PlayerStats stats;

    private bool used = false;

    // On collision, check for player tag and add health
    private void OnTriggerEnter2D(Collider2D col)
    {
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        if (col.CompareTag("Player") && used == false)
        {
            used = true;
            Destroy(gameObject);

            // need merge into dev
            // stats.SetCurrHearts(stats.GetMaxHearts());
        }
    }
}
