using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FanRecoverSequence : MonoBehaviour
{
    int playHash = Animator.StringToHash("Play");
    Animator animator;

    Rigidbody2D[] allRigidbodies;
    Collider2D[] allColliers;

    void Start()
    {
        animator = GetComponent<Animator>();
        allRigidbodies = GetComponentsInChildren<Rigidbody2D>();
        allColliers = GetComponentsInChildren<Collider2D>();
    }

    public void Play()
    {
        animator.SetTrigger(playHash);
        foreach(Rigidbody2D rigidbody in allRigidbodies)
        {
            rigidbody.Sleep();
        }
        foreach (Collider2D collider in allColliers)
        {
            collider.enabled = false;
        }
    }

    public void End()
    {
        foreach (Rigidbody2D rigidbody in allRigidbodies)
        {
            rigidbody.WakeUp();
        }
        foreach (Collider2D collider in allColliers)
        {
            collider.enabled = true;
        }
    }
}
