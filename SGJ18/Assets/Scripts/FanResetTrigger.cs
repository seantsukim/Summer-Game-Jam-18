using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanResetTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTakeoverControl takeoverControl = collision.gameObject.GetComponent<PlayerTakeoverControl>();
        if (takeoverControl)
        {
            takeoverControl.DisableGravity();
            FanRecoverSequence cutscene = takeoverControl.gameObject.GetComponent<FanRecoverSequence>();
            cutscene.Play();
        }
    }
}
