using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public KeyCode keyTrigger;

    public string methodName;  //Name of the method the interactable object will call
    //Can be in a different script, but must be script on the same object

    bool inRange = false;

    void Update()
    {
        if (inRange && Input.GetKeyDown(keyTrigger))
        {
            //Perform task
            Debug.Log(keyTrigger + " pressed");
            SendMessage(methodName);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        //Detect if player
        if (target.tag == "Player")
        {
            inRange = true;
            //Debug.Log("Entering radius of " + gameObject.name);
            //Have Key Prompt appear
            gameObject.transform.GetChild(0).gameObject.active = true;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        //Detect if player
        if (target.tag == "Player")
        {
            inRange = false;
            //Debug.Log("Exiting radius" + gameObject.name);
            //Have Key prompt disappear
            gameObject.transform.GetChild(0).gameObject.active = false;
        }
    }
}
