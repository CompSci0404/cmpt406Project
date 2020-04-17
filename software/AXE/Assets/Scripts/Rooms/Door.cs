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

    [SerializeField]
    Collider2D collider;
    [SerializeField]
    SpriteRenderer spriteOn;
    [SerializeField]
    SpriteRenderer spriteOff;


    [SerializeField]
    private Door destination;


    private void Start()
    {
        if (null == destination)
        {
            Debug.Log("Door removed due to no destination");
            Destroy(gameObject);
        }

        TurnOn();
    }

    public void TurnOn()
    {
        collider.enabled = true;
        spriteOn.enabled = true;
        spriteOff.enabled = false;
    }

    public void TurnOff()
    {
        collider.enabled = false;
        spriteOn.enabled = false;
        spriteOff.enabled = true;
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
                case Compass.North:
                    obj.transform.position = destination.transform.position + Vector3.down;
                    break;
                case Compass.East:
                    obj.transform.position = destination.transform.position + Vector3.left;
                    break;
                case Compass.South:
                    obj.transform.position = destination.transform.position + Vector3.up;
                    break;
                case Compass.West:
                    obj.transform.position = destination.transform.position + Vector3.right;
                    break;
                default:
                    Debug.LogError("Reached default in switch statement.");
                    break;
            }
        }
    }
}
