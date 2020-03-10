using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorData
{
    public Door.Facing facing;
    public Vector2Int position;
    public DoorData pairedDoor;

    public DoorData(Door.Facing facing, Vector2Int position, DoorData door = null)
    {
        this.facing = facing;
        this.position = position;
        if (null != pairedDoor)
            PairDoors(door);
    }

    public void PairDoors(DoorData door)
    {
        pairedDoor = door;
        door.pairedDoor = this;
    }
}
