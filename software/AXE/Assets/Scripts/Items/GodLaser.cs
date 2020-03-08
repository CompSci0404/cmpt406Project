using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodLaser : ItemClass
{

    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;
    private PlayerStats stats;

    [SerializeField] private GameObject spellIndicatior;

    private bool usable;

    private Vector2 lookDirection;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UseGodLaser;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        angle = playerCont.GetComponent<MainControls>().getRSAngle();
        lookDirection = playerCont.GetComponent<MainControls>().getRSDirection();
        
    }
    public void UseGodLaser()
    {
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().getControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }


        
        RaycastHit2D[] hitEnemies = Physics2D.BoxCastAll(playerRB.transform.position, new Vector2(1, 1), angle, new Vector2(lookDirection.y, lookDirection.x), 30f);
        GameObject laser = Instantiate(spellIndicatior, playerRB.transform.position, Quaternion.Euler(0, 0, angle));
        for (int i = 0; i < hitEnemies.Length; i++)
         {
            AIClass enemy = hitEnemies[i].transform.GetComponent<AIClass>();
            if (enemy != null)
             {
                 Debug.Log(enemy);
                 enemy.Damage(stats.GetDamage() * 4);
             }


         }
         StartCoroutine(deleteEffects(laser));

    }

    IEnumerator deleteEffects(GameObject effect)
    {
        yield return new WaitForSeconds(1f);
        Destroy(effect);
    }
    
    /*
    //private void OnDrawGizmos()
    {
        Gizmos.DrawLine(playerRB.transform.position, new Vector3(playerRB.transform.position.x + 10, playerRB.transform.position.y + 10, playerRB.transform.position.z));
        Gizmos.DrawCube(new Vector3(playerRB.transform.position.x, playerRB.transform.position.y, playerRB.transform.position.z), new Vector3(1, 1, 0));
    }
    */

}
