using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    private struct RoomData
    {
        public int roomNumber;

        public enum RoomType
        {
            Normal,     // 1x1 rooms
            Large,      // lower part of 2x1 rooms
            Extension,  // upper part of 2x1 rooms
            Start,      // room in which player spawns
            Boss        // room in which boss and exit appears
        }
        RoomType roomType;

        public RoomData(int roomNumber, RoomType roomType)
        {
            this.roomNumber = roomNumber;

            this.roomType = roomType;
        }
    }

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

        // TODO: replace with variables / non-magic numbers
        int width = 7;
        int height = 7;

        Vector2Int StartingPosition()
        {
            Vector2Int pos = new Vector2Int();

            int border = Random.Range(0, 4);
            if (border == 0)
            {
                pos.y = 0;
                pos.x = Random.Range(0, width);
            }
            else if (border == 1)
            {
                pos.x = 0;
                pos.y = Random.Range(0, height);
            }
            else if (border == 2)
            {
                pos.y = height - 1;
                pos.x = Random.Range(0, width);
            }
            else if (border == 3)
            {
                pos.x = width - 1;
                pos.y = Random.Range(0, height);
            }

            return pos;
        }

        Vector2Int curPos = StartingPosition();

        bool RoomGeneration()
        {




            return false;
        }

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
