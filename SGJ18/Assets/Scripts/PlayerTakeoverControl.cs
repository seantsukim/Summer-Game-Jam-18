using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerTakeoverControl : MonoBehaviour
{
    private PlayerMovement movementRef;

	// Use this for initialization
	void Start ()
    {
        movementRef = GetComponent<PlayerMovement>();
	}
	
	public void SuspendPlayerControl()
    {
        movementRef.AllowPlayerControl(false);
    }

    public void ResumePlayerControl()
    {
        movementRef.AllowPlayerControl(true);
    }

    public void DisableGravity()
    {
        Rigidbody2D[] dragonRigidbodies = GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D rigidbody in dragonRigidbodies)
        {
            rigidbody.gravityScale = 0f;
        }
    }

    public void EnableGravity()
    {
        Rigidbody2D[] dragonRigidbodies = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rigidbody in dragonRigidbodies)
        {
            rigidbody.gravityScale = 10f;
        }
    }
}
