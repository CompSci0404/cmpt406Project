using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public Vector2Int dimensions;

    public List<Door> northDoors;
    public List<Door> eastDoors;
    public List<Door> southDoors;
    public List<Door> westDoors;

    // Get relative area on a room-sized grid (bottom left: 0,0)
    public Rect GetRect(Vector2 position)
    {
        return new Rect(position, dimensions);
    }

    public bool HasDoor(Door.Facing direction)
    {
        switch (direction)
        {
            case Door.Facing.North:
                return 0 < northDoors.Count;
            case Door.Facing.East:
                return 0 < eastDoors.Count;
            case Door.Facing.South:
                return 0 < southDoors.Count;
            case Door.Facing.West:
                return 0 < westDoors.Count;
        }
        return false;
    }

    public Door GetDoor(Door.Facing direction, int selection)
    {
        switch (direction)
        {
            case Door.Facing.North:
                return northDoors[selection];
            case Door.Facing.East:
                return eastDoors[selection];
            case Door.Facing.South:
                return southDoors[selection];
            case Door.Facing.West:
                return westDoors[selection];
        }
        return null;
    }

    public List<Door> GetDoors(Door.Facing direction)
    {
        switch (direction)
        {
            case Door.Facing.North:
                return northDoors;
            case Door.Facing.East:
                return eastDoors;
            case Door.Facing.South:
                return southDoors;
            case Door.Facing.West:
                return westDoors;
        }

        return null;
    }

    public bool HasNorthDoor()
    {
        return 0 != northDoors.Count;
    }

    public Door GetNorthDoor(int selection)
    {
        if (selection >= northDoors.Count)
        {
            Debug.LogError("GetNorthDoor: Index out of range");
            return null;
        }

        return northDoors[selection];
    }

    public List<Door> GetNorthDoors()
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

    public Door GetEastDoor(int selection)
    {
        if (selection > eastDoors.Count)
        {
            Debug.LogError("GetEastDoor: Index out of range");
            return null;
        }

        return eastDoors[selection];
    }

    public List<Door> GetEastDoors()
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

    public Door GetSouthDoor(int selection)
    {
        if (selection > southDoors.Count)
        {
            Debug.LogError("GetSouthDoor: Index out of range");
            return null;
        }

        return southDoors[selection];
    }

    public List<Door> GetSouthDoors()
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

    public Door GetWestDoor(int selection)
    {
        if (selection > westDoors.Count)
        {
            Debug.LogError("GetWestDoor: Index out of range");
            return null;
        }

        return westDoors[selection];
    }

    public List<Door> GetWestDoors()
    {
        if (!HasWestDoor())
        {
            Debug.LogError("GetWestDoors: Getting an empty list");
        }

        return westDoors;
    }
}
