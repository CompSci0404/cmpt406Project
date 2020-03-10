using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> roomPrefabs;

    private Dictionary<Vector2Int, GameObject> rooms;
    private Dictionary<Vector2Int, RoomData> model;

    private void Awake()
    {
        rooms = new Dictionary<Vector2Int, GameObject>();
        model = new Dictionary<Vector2Int, RoomData>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Dictionary<Vector2Int, RoomData> GenerateModel()
    {
        Dictionary<Vector2Int, RoomData> tempModel = new Dictionary<Vector2Int, RoomData>();



        return tempModel;
    }

    private void LoadRooms()
    {
        foreach (Vector2Int roomPos in model.Keys)
        {
            RoomData roomData = model[roomPos];

            if (roomData.roomNumber > 0)
            {
                GameObject original = roomPrefabs[roomData.roomNumber-1];
                Vector2 position = (Vector2)roomPos;
                Quaternion rotation = Quaternion.identity;

                GameObject room = Instantiate(original, position, rotation);

                room.SendMessage("");
            }
        }
    }

    private List<Vector2Int> GetNeighbours(Vector2Int room)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();

        return neighbours;
    }

}
