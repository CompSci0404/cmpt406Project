using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    [SerializeField]
    Vector2Int dimensions;

    [System.Serializable]
    public struct Doors
    {
        public Vector2Int north;
        public Vector2Int east;
        public Vector2Int east2;
        public Vector2Int south;
        public Vector2Int west;
        public Vector2Int west2;
    }

    public Doors doors;
}
