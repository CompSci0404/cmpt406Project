using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData
{
    public int roomNumber;
    public Vector2Int roomSize;
    public List<DoorData> doors;

    public RoomData(int roomNumber, Vector2Int roomSize, List<DoorData> doors)
    {
        this.roomNumber = roomNumber;
        this.roomSize = roomSize;
        this.doors = doors;
    }

}
