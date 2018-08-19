using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameObject wd = GameObject.FindWithTag("WallOfDoom");
            if (wd != null)
            {
                GameObject.FindWithTag("WallOfDoom").active = false;
            }
            //Do level end sequence
            Debug.Log("Level End Sequence");
        }
    }
}
