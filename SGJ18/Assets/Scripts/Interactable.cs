using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public KeyCode keyTrigger;
    //public string className;
    public string methodName;

    bool inRange = false;

    void Update()
    {
        if (Input.GetKeyDown(keyTrigger) && inRange)
        {
            //Perform task
            Debug.Log(keyTrigger + " pressed");
            SendMessage(methodName);
        }
    }

    void OnTriggerEnter2D()
    {
        //Detect if player
        inRange = true;
        Debug.Log("Entering radius of " + gameObject.name);
    }

    void OnTriggerExit2D()
    {
        //Detect if player
        inRange = false;
        Debug.Log("Exiting radius" + gameObject.name);
    }
}
