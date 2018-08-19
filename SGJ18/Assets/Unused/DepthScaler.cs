using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthScaler : MonoBehaviour
{
    public DepthScalerData depthScalerData;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update ()
    {
        float clampedY = Mathf.Clamp(transform.position.y, depthScalerData.frontPlaneWorldY, depthScalerData.backPlaneWorldY);
        float frac = (clampedY - depthScalerData.frontPlaneWorldY) / (depthScalerData.backPlaneWorldY - depthScalerData.frontPlaneWorldY);
        float scaleFactor = depthScalerData.depthScaleCurve.Evaluate(frac);
        transform.localScale = originalScale * scaleFactor;
	}
}
