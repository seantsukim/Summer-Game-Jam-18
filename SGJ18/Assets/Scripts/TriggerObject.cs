using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {

    public GameObject triggeredObject;

    //Trigger that sets triggeredObject active when the player enters


    void OnTriggerEnter2D(Collider2D target)
    {
        //Debug.Log("triggered!!!");
        if (target.tag == "Player")
        {
            Debug.Log(target.gameObject);
            triggeredObject.SetActive(true);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
