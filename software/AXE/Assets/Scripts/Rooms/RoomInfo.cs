using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public Vector2Int dimensions;

    private struct DoorData
    {
        Transform door;
        Door.Compass facing;
        Vector2 targetPosition;
    }

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
        if (selection >= northDoors.Count)
        {
            Debug.LogError("GetNorthDoor: Index out of range");
            return null;
        }

        return northDoors[selection];
    }

    public List<Transform> GetNorthDoors()
    {
        if (!HasNorthDoor())
        {
            Debug.LogError("GetNorthDoors: Getting an empty list");
        }

        return northDoors;
    }

    public bool HasEastDoor()
    {
        return 0 != eastDoors.Count;
    }

    public Transform GetEastDoor(int selection)
    {
        if (selection > eastDoors.Count)
        {
            Debug.LogError("GetEastDoor: Index out of range");
            return null;
        }

        return eastDoors[selection];
    }

    public List<Transform> GetEastDoors()
    {
        if (!HasEastDoor())
        {
            Debug.LogError("GetEastDoors: Getting an empty list");
        }

        return eastDoors;
    }

    public bool HasSouthDoor()
    {
        return 0 != southDoors.Count;
    }

    public Transform GetSouthDoor(int selection)
    {
        if (selection > southDoors.Count)
        {
            Debug.LogError("GetSouthDoor: Index out of range");
            return null;
        }

        return southDoors[selection];
    }

    public List<Transform> GetSouthDoors()
    {
        if (!HasSouthDoor())
        {
            Debug.LogError("GetSouthDoors: Getting an empty list");
        }

        return southDoors;
    }

    public bool HasWestDoor()
    {
        return 0 != westDoors.Count;
    }

    public Transform GetWestDoor(int selection)
    {
        if (selection > westDoors.Count)
        {
            Debug.LogError("GetWestDoor: Index out of range");
            return null;
        }

        return westDoors[selection];
    }

    public List<Transform> GetWestDoors()
    {
        if (!HasWestDoor())
        {
            Debug.LogError("GetWestDoors: Getting an empty list");
        }

        return westDoors;
    }
}
