using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    Vector2 roomSize;

    // Tile-to-screen ratio: 32x18
    readonly float roomWidth = 28f;
    readonly float roomHeight = 14f;

    int minEnemies = 3;
    int maxEnemies = 5;

    public GameObject enemy;

    void Awake()
    {
        roomSize = new Vector2(roomWidth, roomHeight);
        enemy = Resources.Load<GameObject>("Prefabs/EnemyDummy");

        for (int i=0; i < Random.Range(minEnemies, maxEnemies+1); i++)
        {
            Vector2 enemyPos = (Vector2)(transform.position) + new Vector2(Random.Range(-roomWidth/2, roomWidth/2), Random.Range(-roomHeight/2, roomHeight/2));
            Instantiate(enemy, (Vector3)enemyPos, Quaternion.identity);
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
