using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    bool isClear = false;
    bool isActive = false;
    // ability cooldowns
    int firstClear = 0;
    //

    [SerializeField]
    Transform enemyParent;
    [SerializeField]
    Transform spawnParent;

    int enemyCount;

    List<Transform> enemies;

    DropSystem dropSystem;

    void Awake()
    {
        dropSystem = FindObjectOfType<DropSystem>();
        
        enemyCount = enemyParent.childCount;

        enemies = new List<Transform>();

        for (int i=0; i < enemyParent.childCount; i++)
        {
            //Debug.Log("Enemy counted");
            enemies.Add(enemyParent.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && enemies.Count <= 0)
        {
            SendMessage("RoomClear");
            // ability cooldowns
            firstClear += 1;
            //
        }
        // ability cooldowns
        if (firstClear == 1)
        {
            Debug.Log("cleared");
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().IsAbility())
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Abilities>().GetActiveAbility().GetComponent<ItemClass>().ReduceAbilityCooldown();
            }
        }
        //
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        enemies.Remove(enemy.transform);
        dropSystem.DropFromPools(enemy.transform);
        Destroy(enemy);
    }

    void RoomClear()
    {
        isClear = true;
    }

    void PlayerEnter()
    {
        //Debug.Log("Player entered room");

        isActive = true;
        if (!isClear)
        {
            SpawnEnemies();
        }
    }

    void PlayerExit()
    {
        //Debug.Log("Player exited room");

        isActive = false;
        if (!isClear)
        {
            DespawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        //Debug.Log("Spawning enemies");
        enemyParent.gameObject.SetActive(true);
        for (int i=0; i < enemies.Count; i++)
        {
            //Debug.Log("Enemy Spawned");
            int spawnpoint = i % spawnParent.childCount;
            enemies[i].position = spawnParent.GetChild(spawnpoint).position;
        }
    }

    private void DespawnEnemies()
    {
        //Debug.Log("Despawning enemies");
        enemyParent.gameObject.SetActive(false);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetParent(enemyParent);
        }
    }
}
