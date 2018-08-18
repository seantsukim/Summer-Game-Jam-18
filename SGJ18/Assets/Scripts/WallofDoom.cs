using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallofDoom : MonoBehaviour
{
    public float velocity;

    Rigidbody2D rb;

    Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
