using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbilityColliderHandler : MonoBehaviour
{
    public enum DamageType
    {
        instantDamage,
        damageOverTime,
        crowdControl
    }
    private PlayerStats stats;
    private GameObject playerCont;
    private GameObject curPlayCont;
    [SerializeField] private DamageType myDamageType;
    [SerializeField] private float damageMultiplier;
    [SerializeField] private int duration;

    private bool aoeDamageOn;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get correct stats 
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }

        // damage done all at once
        if (myDamageType == DamageType.instantDamage)
        {
            
            if (collision.GetComponent<AIClass>() != null)
            {
                collision.GetComponent<AIClass>().Damage(stats.GetDamage() * damageMultiplier);
                StartCoroutine(DestroyMe());
            }
        }
        // damage over time
        else if (myDamageType == DamageType.damageOverTime)
        {
            aoeDamageOn = true;
            StartCoroutine(doDamage(collision, duration));
            StartCoroutine(DestroyMe());
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aoeDamageOn = false;
    }

    IEnumerator doDamage(Collider2D collision, int n)
    {
        yield return new WaitForSeconds(1f);
        if (n == 0)
        {
            if (playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>() != null)
            {
                if (playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().GetHasDot())
                {
                    playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().SetDoDot(true);
                }
                
            }
            Destroy(this.gameObject);
        }
        if (collision != null)
        {
            if (collision.GetComponent<AIClass>() != null)
            {
                collision.GetComponent<AIClass>().Damage(stats.GetDamage() * damageMultiplier);
            }
        }
        // maybe return if ai dies;
        
        if (aoeDamageOn)
        {
            coroutine = doDamage(collision, n - 1);
            StartCoroutine(coroutine);
        }

        
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(duration);
        if (playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>() != null && myDamageType == DamageType.damageOverTime)
        {
            if (playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().GetHasDot())
            {
                Debug.Log("do dot" + playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().GetHasDot());
                playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().SetDoDot(true);
            }

        }
        Destroy(this.gameObject);
    }

}

