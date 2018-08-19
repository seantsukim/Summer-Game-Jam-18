using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject partnerVent;

    private IEnumerator coroutine;

    public Component[] playerSprites;
    public Component[] playerColliders;

    GameObject wallOfDoom;

    void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        playerSprites = p.GetComponentsInChildren<SpriteRenderer>();
        playerColliders = p.GetComponentsInChildren<BoxCollider2D>();

        wallOfDoom = GameObject.Find("WallOfDoom");
    }

    void MoveToPartnerVent()
    {
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;

        //Checks if the wall of doom has passed the partner vent
        if (wallOfDoom == null || wallOfDoom.transform.position.x < partnerVent.transform.position.x)
        {
            StartCoroutine(PanCameraBetweenPositions(gameObject.transform.position, partnerVent.transform.position));
        }
        else
        {
            Debug.Log("Wall of doom too far");
        }
    }

    //Pans the camera between the two vents
    IEnumerator PanCameraBetweenPositions(Vector3 start, Vector3 finish)
    {
        GameObject p = GameObject.FindWithTag("Player");

        //set stuff on player to inactive - avoid accidental collisions, etc.
        foreach (SpriteRenderer s in playerSprites)
        {
            s.enabled = false;
        }
        foreach (BoxCollider2D b in playerColliders)
        {
            b.enabled = false;
        }

        //Pans the camera between the two vents
        float distance = Vector3.Distance(start, finish);
        float i = 0F;

        while (i < distance)
        {
            yield return new WaitForSeconds(0.0125F);
            float percent = i / distance;
            p.transform.position = Vector3.Lerp(start, finish, percent);// + new Vector3(0, 0, -10);
            i += 0.25F;
        }

        //set stuff on player active
        foreach (SpriteRenderer s in playerSprites)
        {
            s.enabled = true;
        }
        p.transform.position = partnerVent.transform.position;

        int x = 0;
        while (x < 6)
        {
            //yield return new WaitForSeconds(0.0125F);
            //float percent = i / distance;
            //p.transform.position = Vector3.Lerp(start, finish, percent) + new Vector3(0, 0, -10);
            //i += 0.25F;
            yield return new WaitForSeconds(0.0125F);
            p.transform.position += new Vector3(0, -0.25F, 0);
            x++;
        }
        //p.transform.position = partnerVent.transform.position + new Vector3 (0, -1.5F, 0);

        foreach (BoxCollider2D b in playerColliders)
        {
            b.enabled = true;
        }
    }
}
