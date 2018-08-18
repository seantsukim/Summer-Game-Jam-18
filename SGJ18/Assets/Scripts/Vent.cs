using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject partnerVent;

    void MoveToPartnerVent()
    {
        //GameObject player = GameObject.FindWithTag("Player");
        //player.transform.position = partnerVent.transform.position;
        GameObject.FindWithTag("Player").transform.position = partnerVent.transform.position;
    }
}
