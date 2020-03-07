using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private HeartDisplay Hearts;
    private HUD HUD;

    [SerializeField]
    private ThorAnimationInput thorAnimation;
    [SerializeField]
    private ValkAnimationInput valkAnimation;

    public int controllerNumber;
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

            Debug.Log("Player was hit for " + damage + " damage!");

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
        Debug.Log("RemoveHeart");
        if (controllerNumber == 1)
        {
            HUD.ThorHealth[GetCurrHearts()].GetComponent<HeartDisplay>().isShown = false;
        }
        if (controllerNumber == 2)
        {
            HUD.ValkHealth[GetCurrHearts()].GetComponent<HeartDisplay>().isShown = false;
        }
    }

    // Will have to set to other controller? 
    // Respawns the character with one less life
    private void Respawn()
    {
        // Death animation && give invincibility
        if (controllerNumber == 1) thorAnimation.DeathAnimTrigger();
        if (controllerNumber == 2) valkAnimation.DeathAnimTrigger();

        SetLives(GetLives() - 1);
        Debug.Log("Player lost a life, lives remaining:" + GetLives().ToString());
        SetCurrHearts(GetMaxHearts());
        ResetHearts();
        isInvincible = true;
        Invoke("ResetInvincibility", 1);
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
        Debug.Log("Wah I am dead :(");

        // this will destroy the SwapContoller Object (this can be final death) 
        Destroy(this.gameObject, .5f);
        // create Game Over Screen
        SceneManager.LoadScene(2);
    }

    public void MakeInvincible()
    {
        isInvincible = true;
    }

    public void ResetInvincibility()
    {
        isInvincible = false;
    }

}
