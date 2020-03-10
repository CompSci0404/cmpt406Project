using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public Vector2Int dimensions;

    public List<Transform> northDoors;
    public List<Transform> eastDoors;
    public List<Transform> southDoors;
    public List<Transform> westDoors;


    public Rect GetRect(Vector2 position)
    {
        return new Rect(position, dimensions);
    }

    public bool HasNorthDoor()
    {
        return 0 != northDoors.Count;
    }

    public Transform GetNorthDoor(int selection)
    {
        if (selection > northDoors.Count)
        {
            Debug.LogError("GetNorthDoor: Index out of range");
            return null;
        }

        return northDoors[selection];
    }

    public bool HasEastDoor()
    {
        return 0 != eastDoors.Count;
    }

    public Transform GetEastDoor(int selection)
    {
        if (selection > northDoors.Count)
        {
            Debug.LogError("GetEastDoor: Index out of range");
            return null;
        }

        return northDoors[selection];
    }

    public bool HasSouthDoor()
    {
        return 0 != southDoors.Count;
    }

    public Transform GetSouthDoor(int selection)
    {
        if (selection > northDoors.Count)
        {
            Debug.LogError("GetSouthDoor: Index out of range");
            return null;
        }

        return northDoors[selection];
    }

    public bool HasWestDoor()
    {
        return 0 != westDoors.Count;
    }

    public Transform GetWestDoor(int selection)
    {
        if (selection > northDoors.Count)
        {
            Debug.LogError("GetWestDoor: Index out of range");
            return null;
        }

        return northDoors[selection];
    }

}
