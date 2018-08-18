using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject partnerVent;

    void MoveToPartnerVent()
    {
        //Figure out how to pan camera
        GameObject.FindWithTag("Player").transform.position = partnerVent.transform.position;
    }
}
