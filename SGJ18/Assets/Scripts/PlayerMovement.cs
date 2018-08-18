using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public enum MovementMode
    {
        DISCRETE,
        CONTINUOUS
    }
    public MovementMode movementMode;

    private Rigidbody2D rb2D;
    private Vector2 prevVelocity;

	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        prevVelocity = Vector2.zero;
	}

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(horizontal, vertical).normalized * speed;

        if(movementMode == MovementMode.CONTINUOUS)
        {
            velocity = velocity != Vector2.zero ? velocity : prevVelocity;
        }   
        rb2D.MovePosition(rb2D.position + (velocity * Time.fixedDeltaTime));
        prevVelocity = velocity;
    }
}
