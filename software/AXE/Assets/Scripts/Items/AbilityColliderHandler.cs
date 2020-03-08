using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityColliderHandler : MonoBehaviour
{
    private PlayerStats stats;
    private GameObject playerCont;
    private GameObject curPlayCont;
    [SerializeField] private float damageMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }
        Debug.Log("something");
        if (collision.GetComponent<AIClass>() != null)
        {
            Debug.Log(collision.name);
            collision.GetComponent<AIClass>().Damage(stats.GetDamage() * damageMultiplier);
        }
    }
}

