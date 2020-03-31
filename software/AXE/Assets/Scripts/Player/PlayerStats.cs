using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private HeartDisplay Hearts;
    private HUD HUD;

    [SerializeField]
    private GameObject PlayerInvincibilitySprite;
    [SerializeField]
    private ThorAnimationInput thorAnimation;
    [SerializeField]
    private ValkAnimationInput valkAnimation;

    public int controllerNumber;
    //particle effect when damaged
    public GameObject ParticleDamage;
    private float moveSpeed;
    private float range;
    private float atkForce;
    private float damage;
    private int maxHearts;
    private int currHearts;
    private float attackSpeed;
    private int lives;
    private bool isInvincible;

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public void SetAttackSpeed(float value)
    {
        attackSpeed = value;
    }

    public int GetMaxHearts()
    {
        return maxHearts;
    }

    public void SetMaxHealth(int value)
    {
        maxHearts = value;
    }

    public int GetCurrHearts()
    {
        return currHearts;
    }

    public void SetCurrHearts(int value)
    {
        currHearts = value;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    public float GetRange()
    {
        return range;
    }

    public void SetRange(float value)
    {
        range = value;
    }

    public float GetAtkForce()
    {
        return atkForce;
    }

    public void SetAtkForce(float value)
    {
        atkForce = value;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int life)
    {
        lives = life;
    }

    void Awake()
    {
        // initialize stats
        moveSpeed = 10f;
        range = 1f;
        atkForce = 20f;
        damage = 5f;
        maxHearts = 3;
        currHearts = GetMaxHearts();
        attackSpeed = .25f;
        lives = 10;
        isInvincible = false;
        Hearts = FindObjectOfType<HeartDisplay>();
        HUD = FindObjectOfType<HUD>();
        thorAnimation = GetComponentInParent<ThorAnimationInput>();
        valkAnimation = GetComponentInParent<ValkAnimationInput>();
    }

    public int GetControllerNumber()
    {
        return controllerNumber;
    }

    // Enemy damage will call this method
    public void DamagePlayer(int damage)
    {
        if (isInvincible)
        {
            Debug.Log("Player is invincible!");
        }
        else
        {
            int heart = GetCurrHearts();

            heart -= damage;

            SetCurrHearts(heart);

            RemoveHeart();

            if (GetCurrHearts() <= 0 && GetLives() <= 0)
            {
                Death();
            }
            else if (GetCurrHearts() <= 0 && GetLives() > 0)
            {
                Respawn();
            }
        }
    }

    private void RemoveHeart()
    {
        //Debug.Log("RemoveHeart");
        if (controllerNumber == 1)
        {
            HUD.ThorHealth[GetCurrHearts()].GetComponent<HeartDisplay>().isShown = false;
            Instantiate(ParticleDamage, transform.position, Quaternion.identity);

        }
        if (controllerNumber == 2)
        {
            HUD.ValkHealth[GetCurrHearts()].GetComponent<HeartDisplay>().isShown = false;
            Instantiate(ParticleDamage, transform.position, Quaternion.identity);
        }
    }

    // Will have to set to other controller? 
    // Respawns the character with one less life
    public void Respawn()
    {
        // Death animation && give invincibility
        isInvincible = true;
        this.gameObject.GetComponentInParent<MainControls>().canAttack = false;
        if (controllerNumber == 1) thorAnimation.DeathAnimTrigger();
        if (controllerNumber == 2) valkAnimation.DeathAnimTrigger();
        DontMove();
        SetLives(GetLives() - 1);
        Debug.Log("Player lost a life, lives remaining:" + GetLives().ToString());
        SetCurrHearts(GetMaxHearts());
        ResetHearts();
        PlayerInvincibilitySprite.SetActive(true);
        Invoke("Move", 1.25f);
        Invoke("ResetInvincibility", 1);
    }

    public void DontMove()
    {
        this.GetComponentInParent<PlayerMovement>().enabled = false;
    }

    public void Move()
    {
        this.GetComponentInParent<PlayerMovement>().enabled = true;
        this.gameObject.GetComponentInParent<MainControls>().canAttack = true;
    }

    private void ResetHearts()
    {
        foreach (var Hrt in HUD.ThorHealth)
        {
            Hrt.GetComponent<HeartDisplay>().isShown = true;
        }
        foreach (var Hrt in HUD.ValkHealth)
        {
            Hrt.GetComponent<HeartDisplay>().isShown = true;
        }
    }

    // Full death of player
    public void Death()
    {
        Destroy(this.gameObject, .5f);
        SceneManager.LoadScene(2);
    }

    public void MakeInvincible()
    {
        PlayerInvincibilitySprite.SetActive(true);
        isInvincible = true;
    }

    public void ResetInvincibility()
    {
        isInvincible = false;
        PlayerInvincibilitySprite.SetActive(false);
    }

}
