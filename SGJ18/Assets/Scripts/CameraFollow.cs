using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;

    void Update()
    {
        Camera.main.transform.position = gameObject.transform.position + offset;
    }
}
