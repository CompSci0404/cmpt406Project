using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coin will fly to player when close and add currency to the opposite player
/// </summary>
public class Coin : MonoBehaviour
{
    Rigidbody2D rBody;
    GameObject player;
    Vector2 playerDirection;
    float timeStamp;
    bool flyToPlayer;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (flyToPlayer)
        {
            playerDirection = -(this.transform.position - player.transform.position).normalized;
            rBody.velocity = new Vector2(playerDirection.x, playerDirection.y) * 10f * (Time.time / timeStamp);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("CoinMagnet"))
        {
            timeStamp = Time.time;
            player = GameObject.FindGameObjectWithTag("Player");
            flyToPlayer = true;
        }
        if (col.CompareTag("Player"))
        {
            if (player.GetComponent<MainControls>().GetControllerNumber() == 1)
            {
                //PlayerStats stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
                col.GetComponent<CoinStats>().AddValkCoin(1);
            }
            else
            {
                //PlayerStats stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
                col.GetComponent<CoinStats>().AddThorCoin(1);
            }
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("CoinGrab");
        }
    }
}
