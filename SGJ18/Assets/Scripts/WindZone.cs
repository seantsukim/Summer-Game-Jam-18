using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public Vector2 windDirection;
    public float windStrength;

    void OnValidate()
    {
        windDirection.Normalize();
        windStrength = Mathf.Abs(windStrength);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, windDirection * windStrength);
        Gizmos.DrawRay(ray);
    }
}
