using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodLaser : ItemClass
{
    private GameObject playerCont;
    private Rigidbody2D playerRB;
    private PlayerStats stats;
    Vector2 lookDirection;
    [SerializeField] private GameObject SpellIndicator;
    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UseGodLaser;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }
    public void UseGodLaser()
    {
        
        GameObject droppedLeft = Instantiate(SpellIndicator, playerRB.position, Quaternion.identity);
        Vector2 lookDirection = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical"));
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 180f;

        // search for current player stats
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            playerCont = GameObject.FindWithTag("Thor");
        }
        else
        {
            playerCont = GameObject.FindWithTag("Type2");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(playerRB.transform.position, new Vector2(2f, 5f), LayerMask.NameToLayer("Enemy"));
        Debug.Log(hitEnemies.Length);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i].CompareTag("BaseEnemy"))
            {
                hitEnemies[i].GetComponent<AIClass>().Damage(playerCont.GetComponent<PlayerStats>().GetDamage()*4);
                Debug.Log("GodLaser Used");
            }

        }
        // move back player cont to 
        playerCont = GameObject.FindWithTag("Player");
    }

}
