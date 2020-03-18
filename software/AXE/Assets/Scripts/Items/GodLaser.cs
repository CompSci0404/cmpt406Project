using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodLaser : ItemClass
{

    private GameObject playerCont;
    private GameObject curPlayCont;
    private Rigidbody2D playerRB;
    private PlayerStats stats;

    private Vector2 lookDirection;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UseGodLaser;
        playerCont = GameObject.FindWithTag("Player");
        playerRB = playerCont.GetComponent<Rigidbody2D>();
        setAbilityCooldown(0);
    }

    public void UseGodLaser()
    {
        // make sure we have the right player stat
        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            stats = GameObject.FindWithTag("Thor").GetComponent<PlayerStats>();
        }
        else if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 2)
        {
            stats = GameObject.FindWithTag("Type2").GetComponent<PlayerStats>();
        }

        // box collider 2D Version
        angle = playerCont.GetComponent<MainControls>().GetRSAngle();
        lookDirection = playerCont.GetComponent<MainControls>().GetRSDirection();
        // ability indicator
        GameObject laser = Instantiate((GameObject)Resources.Load("GodLaserIndicator"), playerRB.transform.position, Quaternion.Euler(0, 0, angle)) as GameObject;

        // GodLaser Raycast Version
        // con is not very accurate because of the controls
        // RaycastHit2D[] hitEnemies = Physics2D.BoxCastAll(playerRB.transform.position, new Vector2(1, 1), angle, new Vector2(lookDirection.y, lookDirection.x), 30f);
        // create spell indicator that will land where player aims and will leave an area with box collider
        
        /*
        for (int i = 0; i < hitEnemies.Length; i++)
         {
            AIClass enemy = hitEnemies[i].transform.GetComponent<AIClass>();
            if (enemy != null)
             {
                 Debug.Log(enemy);
                 enemy.Damage(stats.GetDamage() * 4);
             }


         }*/

        // remove the particle effect indicator
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
