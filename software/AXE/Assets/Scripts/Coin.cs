using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            col.GetComponentInChildren<PlayerStats>().AddCoin(1);
            Destroy(gameObject);
        }
        else
        { }
    }
}
