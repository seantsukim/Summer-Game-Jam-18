using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallofDoom : MonoBehaviour
{
    public float wallVelocity;
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(wallVelocity, 0);
    }

    void OnTriggerEnter2D()
    {
        //Detect if it collided with Player
        Debug.Log("Collided");
    }
}
