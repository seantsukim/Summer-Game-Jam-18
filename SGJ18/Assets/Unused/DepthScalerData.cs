using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Depth Scaler Data")]
public class DepthScalerData : ScriptableObject
{
    public AnimationCurve depthScaleCurve;
    public float frontPlaneWorldY;
    public float backPlaneWorldY;
}
