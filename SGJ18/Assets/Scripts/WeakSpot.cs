using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WeakSpot : MonoBehaviour
{
    robot robotRef;
    BoxCollider2D mCollider;

	// Use this for initialization
	void Start ()
    {
        robotRef = GetComponentInParent<robot>();
        mCollider = GetComponent<BoxCollider2D>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        robotRef.Damage();
    }

    public void SetWeakSpotActive(bool isActive)
    {
        mCollider.enabled = isActive;
    }
}
