using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    public bool isStart;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTakeoverControl takeoverControl = collision.gameObject.GetComponent<PlayerTakeoverControl>();
        if (takeoverControl)
        {
            if(isStart)
            {
                takeoverControl.SuspendPlayerControl();
                takeoverControl.EnableGravity();
            }
            else
            {
                takeoverControl.ResumePlayerControl();
                takeoverControl.DisableGravity();
            }           
        }
    }
}
