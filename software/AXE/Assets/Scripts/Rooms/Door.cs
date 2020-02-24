using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum Compass
    {
        North, East, South, West
    };

    public Compass direction;

    private Door destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignPartner(Door door)
    {
        destination = door;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (!player.CompareTag("Player"))
        {
            return;
        }

        if (null == destination)
        {
            // throw new MissingReferenceException("The collided door does not have a destination.");
            Debug.LogError("This door has no destination!");
            return;
        }

        switch(direction)
        {
            case Compass.North:
                player.transform.position = destination.transform.position + Vector3.up;
                break;
            case Compass.East:
                player.transform.position = destination.transform.position + Vector3.right;
                break;
            case Compass.South:
                player.transform.position = destination.transform.position + Vector3.down;
                break;
            case Compass.West:
                player.transform.position = destination.transform.position + Vector3.left;
                break;
            default:
                Debug.LogError("Reached default in switch statement.");
                break;
        }

    }
}
