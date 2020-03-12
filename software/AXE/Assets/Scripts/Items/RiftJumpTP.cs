using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftJumpTP : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private GameObject playerCont;
    private Rigidbody2D projectileRB;
    // Start is called before the first frame update
    private void Start()
    {
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
        projectileRB = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = projectileRB.transform.position.x - playerRB.transform.position.x;
        float y = projectileRB.transform.position.y - playerRB.transform.position.y;
        Debug.Log(x);
        Debug.Log(y);
        if (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)) >= 10f && Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)) <= 11f)
        {
            Debug.Log("nothing hit");
            playerRB.transform.position = new Vector2(projectileRB.transform.position.x, projectileRB.transform.position.y);
            Destroy(this.gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if projectile hits one of the tags it wont teleport
        string[] tags = { "Player", "Arrow", "Projectile" };
        for (int i = 0; i < tags.Length; i++)
        {
            if (collision.gameObject.CompareTag(tags[i])) return;
        }

        Debug.Log(collision.gameObject.name);
        playerRB.transform.position = new Vector2(projectileRB.transform.position.x + (-.5f), projectileRB.transform.position.y + (-.5f));
        Destroy(this.gameObject);
        
        
    }
}
