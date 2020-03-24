using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public enum Facing
    {
        North, East, South, West
    };

    public Facing direction;

    public Vector2Int position;

    [SerializeField]
    private Door destination;

    private void Start()
    {
        if (null == destination)
        {
            Debug.Log("Door removed due to no destination");
            Destroy(gameObject);
        }
    }

    // Get relative position on a room-sized grid (bottom left: 0,0)
    public Vector2Int GetPosition()
    {
        return position;
    }

    public Facing GetDirection()
    {
        return direction;
    }

    // Get relative destination on a room-sized grid (bottom left: 0,0)
    public Vector2Int GetDestination()
    {
        Vector2Int destination = position;
        switch(direction)
        {
            case Facing.North:
                destination += Vector2Int.up;
                break;
            case Facing.East:
                destination += Vector2Int.right;
                break;
            case Facing.South:
                destination += Vector2Int.down;
                break;
            case Facing.West:
                destination += Vector2Int.left;
                break;
        }

        return destination;
    }

    public void AssignPartner(Door door)
    {
        destination = door;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Player"))
        {
            if (null == destination)
            {
                // throw new MissingReferenceException("The collided door does not have a destination.");
                Debug.LogError("This door has no destination!");
                return;
            }

            switch (destination.direction)
            {
                case Facing.North:
                    obj.transform.position = destination.transform.position + Vector3.down;
                    break;
                case Facing.East:
                    obj.transform.position = destination.transform.position + Vector3.left;
                    break;
                case Facing.South:
                    obj.transform.position = destination.transform.position + Vector3.up;
                    break;
                case Facing.West:
                    obj.transform.position = destination.transform.position + Vector3.right;
                    break;
                default:
                    Debug.LogError("Reached default in switch statement.");
                    break;
            }
        }
    }
}
