using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    private Dictionary<Vector2Int, GameObject> rooms;
    private Dictionary<Vector2Int, int> model;


    [SerializeField]
    List<GameObject> roomPrefabs;

    private void Awake()
    {
        rooms = new Dictionary<Vector2Int, GameObject>();
        model = new Dictionary<Vector2Int, int>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Dictionary<Vector2Int, int> GenerateModel()
    {
        Dictionary<Vector2Int, int> tempModel = new Dictionary<Vector2Int, int>();

        // TODO: replace with variables
        int width = 7;
        int height = 7;

        bool RoomGeneration()
        {


            return false;
        }

        return null;
    }

    private void LoadRooms()
    {

    }

    private List<Vector2Int> GetNeighbours(Vector2Int room)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();

        return neighbours;
    }

}
