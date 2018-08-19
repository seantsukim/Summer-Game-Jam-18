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
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        screenPoint.y = Mathf.Clamp(screenPoint.y, depthScalerData.frontPlanePixelHeight, depthScalerData.backPlanePixelHeight);
        float frac = (screenPoint.y - depthScalerData.frontPlanePixelHeight) / (depthScalerData.backPlanePixelHeight - depthScalerData.frontPlanePixelHeight);
        float scaleFactor = depthScalerData.depthScaleCurve.Evaluate(frac);
        transform.localScale = originalScale * scaleFactor;
	}
}
