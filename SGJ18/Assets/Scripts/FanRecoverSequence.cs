using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerTakeoverControl))]
public class FanRecoverSequence : MonoBehaviour
{
    PlayerTakeoverControl takeoverControlRef;

    int playHash = Animator.StringToHash("Play");
    Animator animator;

    Rigidbody2D[] allRigidbodies;
    Collider2D[] allColliers;

    void Start()
    {
        takeoverControlRef = GetComponent<PlayerTakeoverControl>();
        animator = GetComponent<Animator>();
        allRigidbodies = GetComponentsInChildren<Rigidbody2D>();
        allColliers = GetComponentsInChildren<Collider2D>();
    }

    public void Play()
    {
        transform.rotation = Quaternion.identity;
        foreach(Rigidbody2D rigidbody in allRigidbodies)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0f;
            rigidbody.isKinematic = true;
        }
        foreach (Collider2D collider in allColliers)
        {
            collider.enabled = false;
        }
        animator.SetTrigger(playHash);
    }

    public void End()
    {
        foreach (Rigidbody2D rigidbody in allRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        foreach (Collider2D collider in allColliers)
        {
            collider.enabled = true;
        }
        takeoverControlRef.ResumePlayerControl();
    }
}
