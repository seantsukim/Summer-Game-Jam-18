using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WindRegion : MonoBehaviour
{
    public Vector2 windDirection;
    [Range(0f, 0.1f)]
    public float windStrength;

    void OnValidate()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        windDirection.Normalize();
    }

    void OnDrawGizmosSelected()
    {
        Vector3 endPoint = transform.position + new Vector3(windDirection.x, windDirection.y) * windStrength * 10;
        Gizmos.DrawLine(transform.position, endPoint);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if(playerMovement)
        {
            playerMovement.SetInWindZone(windDirection * windStrength);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            playerMovement.ExitWindZone();
        }
    }
}
