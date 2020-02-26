using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    bool isClear = false;
    bool isActive = false;

    [SerializeField]
    Transform enemyParent;
    [SerializeField]
    Transform spawnParent;

    int enemyCount;

    List<Transform> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = enemyParent.childCount;

        enemies = new List<Transform>();

        for (int i=0; i < enemyParent.childCount; i++)
        {
            enemies.Add(enemyParent.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && enemies.Count <= 0)
        {
            SendMessage("RoomClear");
        }
    }

    void RoomClear()
    {
        isClear = true;
    }

    void PlayerEnter()
    {
        Debug.Log("Player entered room");

        isActive = true;
        if (!isClear)
        {
            SpawnEnemies();
        }
    }

    void PlayerExit()
    {
        Debug.Log("Player exited room");

        isActive = false;
        if (!isClear)
        {
            DespawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        Debug.Log("Spawning enemies");
        for (int i=0; i < enemies.Count; i++)
        {
            int spawnpoint = i % spawnParent.childCount;
            enemies[i].SetParent(spawnParent.GetChild(spawnpoint));
        }
    }

    private void DespawnEnemies()
    {
        Debug.Log("Despawning enemies");
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetParent(enemyParent);
        }
    }
}
