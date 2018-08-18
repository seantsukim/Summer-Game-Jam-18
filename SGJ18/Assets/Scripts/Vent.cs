using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject partnerVent;

    private IEnumerator coroutine;

    void MoveToPartnerVent()
    {
        //Figure out how to pan camera
        //GameObject.FindWithTag("Player").transform.position = partnerVent.transform.position;

        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
        //coroutine = PanCameraBetweenPositions(p.transform.position, partnerVent.transform.position);
        // StartCoroutine("coroutine");
        StartCoroutine(PanCameraBetweenPositions(playerPos, partnerVent.transform.position));
    }

    IEnumerator PanCameraBetweenPositions(Vector3 start, Vector3 finish)
    {
        GameObject p = GameObject.FindWithTag("Player");
        //p.active = false;
        float distance = Vector3.Distance(start, finish);
        int i = 0;
        while (i < distance)
        {
            yield return new WaitForSeconds(0.05F);
            float percent = i / distance; 
            p.transform.position = Vector3.Lerp(start, finish, percent) + new Vector3(0, 0, -10);
            i++;
        }
        //p.active = true;
        p.transform.position = partnerVent.transform.position;
    }
}
